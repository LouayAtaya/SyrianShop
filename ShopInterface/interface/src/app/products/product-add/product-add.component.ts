import { Product } from './../../models/product';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-product-add',
  templateUrl: './product-add.component.html',
  styleUrls: ['./product-add.component.sass']
})
export class ProductAddComponent implements OnInit {

  Product:Product=new Product();

  constructor() { }

  ngOnInit(): void {
    
  }

  addProduct(addProductForm){
    
  }

}
