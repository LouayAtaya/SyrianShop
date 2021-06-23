import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Product } from 'src/app/models/product';
import { ProductsService } from 'src/app/services/products.service';

@Component({
  selector: 'app-product-update',
  templateUrl: './product-update.component.html',
  styleUrls: ['./product-update.component.sass']
})
export class ProductUpdateComponent implements OnInit {
  productId:number;

  product:Product;
  
  message:string;

  constructor(private productsService: ProductsService , private route: ActivatedRoute) {
    
   }

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
      error=> this.message="No Product Found, Please check the Notification, or contact System Adminstrator"
    )
  }
}
