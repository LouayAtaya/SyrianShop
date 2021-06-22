import { Product } from './../../models/product';
import { ProductsService } from './../../services/products.service';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { stringify } from '@angular/compiler/src/util';

@Component({
  selector: 'app-product-detail',
  templateUrl: './product-detail.component.html',
  styleUrls: ['./product-detail.component.sass']
})
export class ProductDetailComponent implements OnInit {
  productId:number;

  product:Product;
  
  message:string;

  constructor(private productsService: ProductsService , private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.route.paramMap.subscribe(
      params=>{
        this.productId=Number.parseInt(params.get("id"));
        console.log(this.productId)
      }
    )
    this.getProduct();
  }

  getProduct(){
    this.productsService.get(this.productId).subscribe(
      data=>{
        this.product=data;
        console.log(this.product);
      },
      error=> this.message="No Products Found, Please cheke the Notification, or contact System Adminstrator"
    )
  }
}
