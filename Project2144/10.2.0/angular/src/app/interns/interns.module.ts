import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SharedModule } from 'primeng/api';

import { InternsComponent } from './interns.component';
import { InternsRoutingModule } from './interns-routing.module';



@NgModule({
  imports: [
    CommonModule,
    SharedModule,
    InternsRoutingModule,
    InternsComponent   
  ],
 
})
export class internsModule {}
