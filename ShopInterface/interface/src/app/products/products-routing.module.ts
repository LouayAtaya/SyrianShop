import { ProductUpdateComponent } from './product-update/product-update.component';
import { ProductDetailComponent } from './product-detail/product-detail.component';
import { ProductListComponent } from './product-list/product-list.component';
import { NgModule } from '@angular/core';
import { Routes, RouterModule, ActivatedRoute } from '@angular/router';
import { ProductAddComponent } from './product-add/product-add.component';
import { AuthGuard } from '../guards/auth.guard';

const routes: Routes = [
  {path:"", component:ProductListComponent, canActivate:[AuthGuard] , data:{roles:'Admin'}},
  {path:"add", component:ProductAddComponent, canActivate:[AuthGuard] , data:{roles:'Admin'}},
  {path:":id", component:ProductDetailComponent},
  {path:"update/:id", component:ProductUpdateComponent, canActivate:[AuthGuard] , data:{roles:'Admin'}}

];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ProductsRoutingModule { }
