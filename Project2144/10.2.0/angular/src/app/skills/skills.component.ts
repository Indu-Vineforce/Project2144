import { Component, OnInit } from '@angular/core';
import { CreateSkillDto, SkillServiceProxy, UpdateSkillDto } from '../../shared/service-proxies/service-proxies';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { LocalizePipe } from '../../shared/pipes/localize.pipe';
@Component({
  selector: 'app-skills',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule, LocalizePipe],
  templateUrl: './skills.component.html',
  styleUrls: ['./skills.component.css']
})
export class SkillsComponent implements OnInit {
  skills: CreateSkillDto[] = [];
  skillForm: FormGroup;
  isEditing = false;
  currentSkillId: number | null = null;
  constructor(
    private skillService: SkillServiceProxy,
    private fb: FormBuilder
  ) {
    this.skillForm = this.fb.group({
      name: ['', Validators.required]
    });
  }
  ngOnInit(): void {
    this.getAllSkills();
  }
  getAllSkills(): void {
    this.skillService.getAll().subscribe({
      next: (result) => {
        this.skills = result || [];
      },
      error: (error) => {
        console.error('Error fetching skills:', error);
        alert('Failed to load skills.');
      }
    });
  }
  deleteSkill(id: number): void {
    if (confirm('Are you sure you want to delete this skill?')) {
      this.skillService.delete(id).subscribe({
        next: () => {
          alert('Skill deleted successfully!');
          this.getAllSkills();
        },
        error: (error) => {
          console.error('Error deleting skill:', error);
          alert('Failed to delete skill.');
        }
      });
    }
  }
  editSkill(skill: UpdateSkillDto): void {
    this.skillForm.patchValue({
      name: skill.name
    });
    this.currentSkillId = skill.id;
    this.isEditing = true;
  }
  saveSkill(): void {
    if (this.skillForm.invalid) {
      alert('Please enter a skill name.');
      return;
    }
    const formValues = this.skillForm.value;
    if (this.isEditing && this.currentSkillId !== null) {
      const updatedSkill = new UpdateSkillDto();
      updatedSkill.id = this.currentSkillId;
      updatedSkill.name = formValues.name;

      this.skillService.update(updatedSkill).subscribe({
        next: () => {
          alert('Skill updated successfully!');
          this.getAllSkills();
          this.resetForm();
        },
        error: (error) => {
          console.error('Error updating skill:', error);
          alert('Failed to update skill.');
        }
      });
    } else {   
      const newSkill = new CreateSkillDto();
      newSkill.name = formValues.name;
      this.skillService.create(newSkill).subscribe({
        next: () => {
          alert('Skill created successfully!');
          this.getAllSkills();
          this.resetForm();
        },
        error: (error) => {
          console.error('Error creating skill:', error);
          alert('Failed to create skill.');
        }
      });
    }
  }
  resetForm(): void {
    this.skillForm.reset();
    this.currentSkillId = null;
    this.isEditing = false;
  }
}