import { UserInfo } from '../models/user-info';
import { Role } from './../models/role';
import { User } from './../models/user';
import { Router } from '@angular/router';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { Config } from 'src/assets/config';
import { UserDto } from '../models/user-dto';
import { JwtHelperService } from "@auth0/angular-jwt";

@Injectable({
  providedIn: 'root'
})
export class UsersService {
  baseUrl:String=Config.devBaseUrl;// environment.baseUrl;

  

  constructor(private httpClient: HttpClient, private router: Router) { }

  public login(userDto:UserDto): Observable<any>{
    return this.httpClient.post<any>(this.baseUrl+"/users/login", userDto)
      .pipe(
        map(data=>{
          if(data){
            localStorage.setItem("token",data.token);
          }
          return data
        })
      );
  }

  logout(){
    localStorage.removeItem("token");
    this.router.navigateByUrl("/");
  }

  public get currentUser(): UserInfo{
    //check the token
    let token=localStorage.getItem('token');
    
    if(!token) return null;

    let decodedToken=new JwtHelperService().decodeToken(token);
    let userInfo={userId:decodedToken.userId, userName:decodedToken.userName, userRoles:JSON.parse(decodedToken.userRoles)}
    return  userInfo;
  }

  public isAuthenticated():boolean{
    //check the token
    let token=localStorage.getItem('token');
    
    if(token)
    {
      let jwtHelper=new  JwtHelperService();

      let isTokenExpired=jwtHelper.isTokenExpired(token);

      if(!isTokenExpired)
        return true;
    }
    return false;
  }

  isAutherized(requiredRole){
    if(this.isAuthenticated() && this.currentUser && this.currentUser.userRoles){
      let userRoles = this.currentUser.userRoles;

      for(let i=0; i<userRoles.length;i++){         
        if(userRoles[i]===requiredRole)
          return true
      }
     
    }
    return false;
  }

}
