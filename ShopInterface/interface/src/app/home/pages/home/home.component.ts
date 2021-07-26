import { ProductParam } from './../../../models/product-param';
import { Product } from './../../../models/product';
import { ProductsService } from './../../../services/products.service';
import { Component, OnInit } from '@angular/core';
import { ProductPaginationResult } from 'src/app/models/product-pagination-result';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.sass']
})
export class HomeComponent implements OnInit {

  productPaginationResult:ProductPaginationResult;
  products:Product[];

  productParam: ProductParam;

  message:string;

  constructor(private proudctsServcie: ProductsService) { }

  ngOnInit(): void {
    this.productParam=new ProductParam();
    this.productParam.pageSize=6;

    this.getProducts();
  }

  paginate(event) {
    this.productParam.pageStart=event.first; //Index of the first record
    this.productParam.pageSize=event.rows;   //Number of rows to display in new page
    //event.pageCount = Total number of pages
    //event.page = Index of the new page

    this.getProducts();
}

  getProducts(){
    this.proudctsServcie.getAll(this.productParam).subscribe(
      data=>{
        this.productPaginationResult=data;
        this.products=this.productPaginationResult.data;
        console.log(this.products)
      },
      error=>{
        this.message="An Error Has Been Accaurd, Please contact System Adminstrator to solve the problem"
      }
      
    );
  }
}
