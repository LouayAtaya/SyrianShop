import { ProductListComponent } from './products/product-list/product-list.component';
import { NotFoundComponent } from './shared/layout/not-found/not-found.component';
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './home/pages/home/home.component';

const routes: Routes = [
  {path:"", 
    loadChildren:()=> import ('./home/home.module')
      .then(m=>m.HomeModule)
  },

  {path:"products", 
    loadChildren:()=> import ('./products/products.module')
      .then(m=>m.ProductsModule)
  },

  {path:"404", component:NotFoundComponent },

  {path:"**", redirectTo:"/404" }

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
