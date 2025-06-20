import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SharedModule } from 'primeng/api';
import { DepartmentsComponent } from './departments.component';
import { DepartmentsRoutingModule } from './departments-routing.module';



@NgModule({
  imports: [
    CommonModule,
    SharedModule,
    DepartmentsComponent,
    DepartmentsRoutingModule  
  ],
 
})
export class departmentsModule {}
