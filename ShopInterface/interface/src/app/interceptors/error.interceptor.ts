import { ToastrModule } from 'ngx-toastr';
import { catchError } from 'rxjs/operators';
import { Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor
} from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { ToastrService } from 'ngx-toastr';


@Injectable()
export class ErrorInterceptor implements HttpInterceptor {

  constructor(private toastrService: ToastrService ) {}

  intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    const token: string = localStorage.getItem('token');

    if (token) {
        request = request.clone({ headers: request.headers.set('Authorization', 'Bearer ' + token) });
    }

    /*if (!request.headers.has('Content-Type')) {
      request = request.clone({ headers: request.headers.set('Content-Type', 'application/json') });
    }*/

    request = request.clone({ headers: request.headers.set('Accept', 'application/json') });

    return next.handle(request).pipe(
      catchError(errorRes=>{
        if(errorRes){
          this.toastrService.error(errorRes.error.message,errorRes.error.stautusCode)
          /*
          if(errorRes.status===400){
           
            this.toastrService.error(errorRes.error.message,errorRes.error.stautusCode)
          }
          else if(errorRes.status===401){
            this.toastrService.error(errorRes.error.message,errorRes.error.stautusCode)
          }
          else if(errorRes.status===404){
            this.toastrService.error(errorRes.error.message,errorRes.error.stautusCode)
          }
          else if(errorRes.status===500){
            this.toastrService.error(errorRes.error.message,errorRes.error.stautusCode)
          }*/
        }
        return throwError(errorRes)
      })
      
    )
  }
}


