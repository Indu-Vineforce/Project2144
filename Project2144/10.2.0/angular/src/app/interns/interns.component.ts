import { Component, OnInit } from '@angular/core';
import { InternServiceProxy, UpdateInternDto, CreateInternDto } from '../../shared/service-proxies/service-proxies';
import { CommonModule } from '@angular/common';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { LocalizePipe } from '@shared/pipes/localize.pipe';

@Component({

  selector: 'app-interns',
  imports: [CommonModule, ReactiveFormsModule, LocalizePipe],
  templateUrl: './interns.component.html',
  styleUrl: './interns.component.css'
})
export class InternsComponent implements OnInit {
  interns: UpdateInternDto[] = [];
  internForm: FormGroup;
  isEditing = false;
  currentInternId: number | null = null;

  constructor(
    private internService: InternServiceProxy,
    private fb: FormBuilder
  ) {
    this.internForm = this.fb.group({
      name: ['', Validators.required],
      // Add other fields as needed (e.g., age, email)
    });
  }

  ngOnInit(): void {
    this.GetAll();
  }

  GetAll(): void {
    this.internService.getAll().subscribe({
      next: (result) => {
        this.interns = result || [];
        console.log('Interns loaded:', this.interns);
      },
      error: (error) => {
        console.error('Error fetching interns:', error);
        alert('Failed to load interns.');
      }
    });
  }

  saveIntern(): void {
    if (this.internForm.invalid) {
      alert('Please fill in all required fields');
      return;
    }

    const formValues = this.internForm.value;

    if (this.isEditing && this.currentInternId !== null) {
      const updatedIntern = new UpdateInternDto({
        id: this.currentInternId,
        name: formValues.name
        // Add other fields as needed
      });

      this.internService.update(updatedIntern).subscribe({
        next: () => {
          alert('Intern updated successfully!');
          this.GetAll();
          this.resetForm();
        },
        error: (error) => {
          console.error('Update failed:', error);
          const errorMsg = error?.error?.message || 'An error occurred during update.';
          alert('Update failed: ' + errorMsg);
        }
      });
    } else {
      const newIntern = new CreateInternDto({
        name: formValues.name
        // Add other fields as needed
      });

      this.internService.create(newIntern).subscribe({
        next: () => {
          alert('Intern created successfully!');
          this.GetAll();
          this.resetForm();
        },
        error: (error) => {
          console.error('Create failed:', error);
          const errorMsg = error?.error?.message || 'An error occurred during creation.';
          alert('Create failed: ' + errorMsg);
        }
      });
    }
  }

  editIntern(intern: UpdateInternDto): void {
    this.internForm.patchValue({
      name: intern.name
      // Patch other fields as needed
    });

    this.currentInternId = intern.id!;
    this.isEditing = true;
  }

  deleteIntern(id: number): void {
    if (confirm('Are you sure you want to delete this intern?')) {
      this.internService.delete(id).subscribe({
        next: () => {
          alert('Intern deleted successfully!');
          this.GetAll();
        },
        error: (error) => {
          console.error('Delete failed:', error);
          const errorMsg = error?.error?.message || 'An error occurred during deletion.';
          alert('Delete failed: ' + errorMsg);
        }
      });
    }
  }

  resetForm(): void {
    this.internForm.reset();
    this.currentInternId = null;
    this.isEditing = false;
  }
}
