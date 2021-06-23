import { UserInfo } from '../../../models/user-info';
import { UsersService } from './../../../services/users.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-sidebar',
  templateUrl: './sidebar.component.html',
  styleUrls: ['./sidebar.component.sass']
})
export class SidebarComponent implements OnInit {
  currentUser:UserInfo;

  constructor(private usersService: UsersService) { }

  ngOnInit(): void {
    this.currentUser=this.usersService.currentUser;
  }

  isAuthenticated(){
    return this.usersService.isAuthenticated()
  }

  menuItemIsShown(requiredRole){
    return this.usersService.isAutherized(requiredRole);
  }
  
}
