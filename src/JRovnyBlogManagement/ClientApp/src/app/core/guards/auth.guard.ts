import { Injectable } from '@angular/core';
import {
  ActivatedRouteSnapshot,
  CanActivate,
  RouterStateSnapshot,
  UrlTree,
} from '@angular/router';
import { Observable } from 'rxjs';
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

    // Whitelist signin-callback endpoint
    if (state.url.substring(0, signIn.length) === signIn) {
      return true;
    }

    if (this.authService.isSignedIn()) {
      return true;
    }

    this.authService.signIn();
    return false;
  }
}
