import { ProductPaginationResult } from './../models/product-pagination-result';
import { ProductParam } from './../models/product-param';
import { Product } from './../models/product';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Config } from 'src/assets/config';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class ProductsService {

  baseUrl:String=Config.devBaseUrl;// environment.baseUrl;

  constructor(private httpClient: HttpClient) { }

  public getAll(productParam:ProductParam): Observable<ProductPaginationResult>{

    let params= new HttpParams();
    params=params.append("sortBy",productParam.sortBy);
    params=params.append("pageStart",productParam.pageStart.toString());
    params=params.append("pageSize",productParam.pageSize.toString());

    return this.httpClient.get<ProductPaginationResult>(this.baseUrl+"/products",{params:params})
    
  }

  public get(id:number): Observable<Product>{

    return this.httpClient.get<Product>(this.baseUrl+"/products/"+id)
    
  }

  public post(employee: Product):Observable<Product>{
    return this.httpClient.post<Product>(this.baseUrl+"/products",employee);
  }

  public put(id:number,employee: Product):Observable<Product>{
    return this.httpClient.put<Product>(this.baseUrl+"/products/"+id,employee);
  }

  public delete(id:number):Observable<Product>{
    return this.httpClient.delete<Product>(this.baseUrl+"/products/"+id);
  }

}
