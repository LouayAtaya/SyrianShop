import { UsersService } from './../../../services/users.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.sass']
})
export class HeaderComponent implements OnInit {

  constructor(private usersService: UsersService) { }

  ngOnInit(): void {
  
  }

  isAuthentecated(){
    return this.usersService.isAuthenticated();
  }

  logout(){
    this.usersService.logout();
  }

}
