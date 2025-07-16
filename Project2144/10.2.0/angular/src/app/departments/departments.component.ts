import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule, FormBuilder, FormGroup, Validators } from '@angular/forms';
import {
  DepartmentServiceProxy,
  CreateDepartmentDto,
  UpdateDepartmentDto
} from '@shared/service-proxies/service-proxies';
import { LocalizePipe } from '@shared/pipes/localize.pipe';

@Component({
  standalone: true,
  selector: 'app-departments',
  templateUrl: './departments.component.html',
  styleUrls: ['./departments.component.css'],
  imports: [CommonModule, ReactiveFormsModule, LocalizePipe]
})
export class DepartmentsComponent implements OnInit {
  departments: UpdateDepartmentDto[] = [];
  departmentForm: FormGroup;
  isEditing = false;
  currentDepartmentId: number | null = null;

  constructor(
    private departmentService: DepartmentServiceProxy,
    private fb: FormBuilder
  ) {
    this.departmentForm = this.fb.group({
      name: ['', Validators.required]
    });
  }
  ngOnInit(): void {
    this.getAllDepartments();
  }
  getAllDepartments(): void {
    debugger;
    this.departmentService.getAll().subscribe({
      next: (result) => {
        this.departments = result || [];
        console.log('tjsio',result);
      },
      error: (error) => {
        console.error('Error fetching departments:', error);
        alert('Failed to load departments.');
      }
    });
  }
  deleteDepartment(id: number): void {
    if (confirm('Are you sure you want to delete this department?')) {
      this.departmentService.delete(id).subscribe({
        next: () => {
          alert('Department deleted successfully!');
          this.getAllDepartments();
        },
        error: (error) => {
          console.error('Error deleting department:', error);
          alert('Failed to delete department.');
        }
      });
    }
  }
  editDepartment(dept: UpdateDepartmentDto): void {
    this.departmentForm.patchValue({
      name: dept.name
    });
    this.currentDepartmentId = dept.id!;
    this.isEditing = true;
  }

  saveDepartment(): void {
    if (this.departmentForm.invalid) {
      alert('Please enter a department name.');
      return;
    }

    const formValues = this.departmentForm.value;

    if (this.isEditing && this.currentDepartmentId !== null) {
      const updatedDept = new UpdateDepartmentDto();
      updatedDept.id = this.currentDepartmentId;
      updatedDept.name = formValues.name;

      this.departmentService.update(updatedDept).subscribe({
        next: () => {
          alert('Department updated successfully!');
          this.getAllDepartments();
          this.resetForm();
        },
        error: (error) => {
          console.error('Error updating department:', error);
          alert('Failed to update department.');
        }
      });
    } else {
      const newDept = new CreateDepartmentDto();
      newDept.name = formValues.name;

      this.departmentService.create(newDept).subscribe({
        next: () => {
          alert('Department created successfully!');
          this.getAllDepartments();
          this.resetForm();
        },
        error: (error) => {
          console.error('Error creating department:', error);
          alert('Failed to create department.');
        }
      });
    }
  }

  resetForm(): void {
    this.departmentForm.reset();
    this.currentDepartmentId = null;
    this.isEditing = false;
  }
}
