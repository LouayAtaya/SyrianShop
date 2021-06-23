import { SharedModule } from './../shared/shared.module';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HomeComponent } from './pages/home/home.component';
import { AboutUsComponent } from './pages/about-us/about-us.component';
import { HomeRoutingModule } from './home.routing.module';
import { ContactUsComponent } from './pages/contact-us/contact-us.component';
import { LoginComponent } from './pages/login/login.component';
import {PaginatorModule} from 'primeng/paginator';
import { FormsModule } from '@angular/forms';


@NgModule({
  declarations: [HomeComponent, AboutUsComponent, ContactUsComponent, LoginComponent],
  imports: [
    CommonModule,
    HomeRoutingModule,
    FormsModule,
    SharedModule,
    PaginatorModule
  ],
  exports:[
  
  ]
})
export class HomeModule { }
