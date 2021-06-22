import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HeaderComponent } from './layout/header/header.component';
import { SidebarComponent } from './layout/sidebar/sidebar.component';
import { FooterComponent } from './layout/footer/footer.component';
import { RouterModule } from '@angular/router';
import { NotFoundComponent } from './layout/not-found/not-found.component';
import { ContentHeaderComponent } from './layout/content-header/content-header.component';



@NgModule({
  declarations: [HeaderComponent, SidebarComponent, FooterComponent, NotFoundComponent, ContentHeaderComponent],
  imports: [
    CommonModule,
    RouterModule
  ],
  exports:[
    HeaderComponent,
    SidebarComponent,
    FooterComponent,
    NotFoundComponent,
    ContentHeaderComponent
  ]
})
export class SharedModule { }
