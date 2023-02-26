import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot } from '@angular/router';

@Injectable({providedIn: 'root'})
export class AuthGuard implements CanActivate {
  constructor(private router: Router) { }

  canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot) {
    let accessToken = localStorage.getItem('access_token');
    // if(!accessToken || accessToken != 'tokenteste') {
    //   this.router.navigate(['/auth/login']);
    // }
    return true;
  }
}
