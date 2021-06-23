import { ToastrService } from 'ngx-toastr';
import { UsersService } from './../../../services/users.service';
import { UserDto } from './../../../models/user-dto';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.sass']
})
export class LoginComponent implements OnInit {

  userDto:UserDto;

  constructor(private usersServcie: UsersService,private router: Router , private toastrService: ToastrService ) { }

  ngOnInit(): void {
    this.userDto=new UserDto();

    if(this.usersServcie.isAuthenticated())
      this.router.navigate(['/']);
  }

  onSignInSubmit(loginForm){
    
    this.usersServcie.login(this.userDto).subscribe(
      data=>{
        this.toastrService.success("Success, Login");
        this.router.navigateByUrl("/")
      },
      error=>{
        this.toastrService.error("Error Login, Check your credentials, username or password")
      }
    )

  }

}
