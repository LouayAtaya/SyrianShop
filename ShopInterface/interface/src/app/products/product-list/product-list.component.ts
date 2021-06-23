import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { Product } from 'src/app/models/product';
import { ProductPaginationResult } from 'src/app/models/product-pagination-result';
import { ProductParam } from 'src/app/models/product-param';
import { ProductsService } from 'src/app/services/products.service';

@Component({
  selector: 'app-product-list',
  templateUrl: './product-list.component.html',
  styleUrls: ['./product-list.component.sass']
})
export class ProductListComponent implements OnInit {
  productPaginationResult:ProductPaginationResult;
  products:Product[];

  productParam: ProductParam;

  message:string;

  totalRecords: number=1000;
  loading: boolean=false;

  constructor(private proudctsServcie: ProductsService,private toastrService: ToastrService) { }

  ngOnInit(): void {
    this.productParam=new ProductParam();

  }

  getProducts(){
    this.proudctsServcie.getAll(this.productParam).subscribe(
      data=>{
        this.productPaginationResult=data;
        this.products=this.productPaginationResult.data;
      },
      error=>{
        this.message="An Error Has Been Accaurd, Please contact System Adminstrator to solve the problem"
      }
      
    );
  }

  loadProducts(event){
    this.setProductParams(event);

    setTimeout(() => {
      this.getProducts();
      this.loading = false;

    }, 1000);
    this.loading =true ;
  }

  setProductParams(event){
    this.productParam.pageStart=event.first;
    this.productParam.pageSize=event.rows;

    //sort
    let sortBy:String=event.sortField;
    let sortOrder:number=event.sortOrder;

    if(sortBy!=null){
      if(sortBy =="title" && sortOrder == 1){
        this.productParam.sortBy="title"
      }
      else if(sortBy=="title" && sortOrder==-1){
        this.productParam.sortBy="titleDesc"
      }
      else if(sortBy=="description" && sortOrder==1){
        this.productParam.sortBy="description"
      }
      else if(sortBy=="description" && sortOrder==-1){
        this.productParam.sortBy="descriptionDesc"
      }
      else if(sortBy=="price" && sortOrder==1){
        this.productParam.sortBy="price"
      }
      else if(sortBy=="price" && sortOrder==-1){
        this.productParam.sortBy="priceDesc"
      }
      else if(sortBy=="quantity" && sortOrder==1){
        this.productParam.sortBy="quantity"
      }
      else if(sortBy=="quantity" && sortOrder==-1){
        this.productParam.sortBy="quantityDesc"
      }
      else if(sortBy=="creationDate" && sortOrder==1){
        this.productParam.sortBy="creationDate"
      }
      else if(sortBy=="creationDate" && sortOrder==-1){
        this.productParam.sortBy="creationDateDesc"
      }
    }

    
  }

  deleteProduct(id){
    if(confirm("do you want Really to delete ")){
      this.proudctsServcie.delete(id)
      .subscribe(
        data=>{
          this.toastrService.success("Product is deleted successfully","deleted");
          this.getProducts();
        },
        error=>{
          console.log(error)
          this.toastrService.error("An Error has been accourd while deleting this product","not deleted");
        }
      );
    }
    
  }

}
