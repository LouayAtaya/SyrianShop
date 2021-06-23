import { FormsModule } from '@angular/forms';
import { SharedModule } from './../shared/shared.module';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ProductsRoutingModule } from './products-routing.module';
import { ProductListComponent } from './product-list/product-list.component';
import { ProductDetailComponent } from './product-detail/product-detail.component';
import { ProductUpdateComponent } from './product-update/product-update.component';
import { ProductAddComponent } from './product-add/product-add.component';
import {TableModule} from 'primeng/table';
import {ButtonModule} from 'primeng/button';

@NgModule({
  declarations: [ProductListComponent, ProductDetailComponent, ProductUpdateComponent, ProductAddComponent],
  imports: [
    CommonModule,
    ProductsRoutingModule,
    SharedModule,
    TableModule,
    ButtonModule,
    FormsModule
  ]
})
export class ProductsModule { }
