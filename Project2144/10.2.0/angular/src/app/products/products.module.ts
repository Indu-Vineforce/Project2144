import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SharedModule } from 'primeng/api';
import {ProductsRoutingModule} from './products-routing.module';
import { ProductsComponent} from './products.component';


@NgModule({
  imports: [
    CommonModule,
    SharedModule,
    ProductsRoutingModule,
    ProductsComponent
     
  ],
 
})
export class productsModule {}
