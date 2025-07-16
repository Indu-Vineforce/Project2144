import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SharedModule } from 'primeng/api';
import { SkillsRoutingModule } from './skills-routing.module';
import { SkillsComponent } from './skills.component';


@NgModule({
  imports: [
    CommonModule,
    SharedModule,
    SkillsRoutingModule,
     SkillsComponent
  ],
 
})
export class skillsModule {}
