import { UserInfo } from '../models/user-info';
import { UsersService } from './../services/users.service';
import { Injectable } from '@angular/core';
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, UrlTree, Router } from '@angular/router';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate {

  currentUser:UserInfo;

  public constructor(private UsersService: UsersService, private router: Router ){
    this.currentUser=this.UsersService.currentUser;
  }

  canActivate(
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): Observable<boolean | UrlTree> | Promise<boolean | UrlTree> | boolean | UrlTree {
      
        let requiredRole=route.data['roles'];
        if(requiredRole && this.UsersService.isAutherized(requiredRole)){
          return true;
        }
   
      this.router.navigate(['/401']);
      return false;
  }
  
}
