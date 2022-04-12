import { Injectable } from '@angular/core';
import {
  ActivatedRouteSnapshot,
  CanActivate,
  RouterStateSnapshot,
  UrlTree,
} from '@angular/router';
import { from, map, Observable } from 'rxjs';
import { AuthService } from '../auth.service';

@Injectable({
  providedIn: 'root',
})
export class AuthGuard implements CanActivate {
  constructor(private authService: AuthService) {}

  canActivate(
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot
  ):
    | Observable<boolean | UrlTree>
    | Promise<boolean | UrlTree>
    | boolean
    | UrlTree {
    const signIn: string = '/signin-callback';
    const signout: string = '/signout';

    // Whitelist signin-callback endpoint
    if (state.url.substring(0, signIn.length) === signIn) {
      return true;
    }

    // Whitelist signout endpoint
    if (state.url.substring(0, signout.length) === signout) {
      return true;
    }

    return from(this.authService.getUser()).pipe(
      map((user) => {
        this.authService.user = user;
        if (user && user.access_token && !user.expired) {
          console.log('User signed in');
          return true;
        } else {
          console.log('User not signed in');
          this.authService.signIn();
          return false;
        }
      })
    );
  }
}
