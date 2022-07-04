import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, CanDeactivate, CanLoad, Route, RouterStateSnapshot, UrlSegment, UrlTree, Router } from '@angular/router';
import { Observable } from 'rxjs';
import {ServiceAuthService} from './auth/Services/service-auth.service';


@Injectable({
  providedIn: 'root'
})
export class GuardGuard implements CanActivate, CanDeactivate<unknown>, CanLoad {


  constructor(private router:Router, private api:ServiceAuthService){

  }
  redirect(flag:boolean):any{
    if(!flag){
      this.router.navigate(['/login', 'login']);
    }
  }
  
  
  canActivate(
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): Observable<boolean | UrlTree> | Promise<boolean | UrlTree> | boolean | UrlTree {
    
      let resul:boolean = this.api.CheckToken();
      this.redirect(resul);
    return resul;
  }
  canDeactivate(
    component: unknown,
    currentRoute: ActivatedRouteSnapshot,
    currentState: RouterStateSnapshot,
    nextState?: RouterStateSnapshot): Observable<boolean | UrlTree> | Promise<boolean | UrlTree> | boolean | UrlTree {
    return true;
  }
  canLoad(
    route: Route,
    segments: UrlSegment[]): Observable<boolean | UrlTree> | Promise<boolean | UrlTree> | boolean | UrlTree {
    return true;
  }
}
