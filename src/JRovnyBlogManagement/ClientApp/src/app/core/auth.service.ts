import { Injectable } from '@angular/core';
import {
  User,
  UserManager,
  UserManagerSettings,
  WebStorageStateStore,
} from 'oidc-client-ts';
import { from, map, Observable, of } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root',
})
export class AuthService {
  public userManager: UserManager;
  public user: User | null;

  constructor() {
    const settings: UserManagerSettings = {
      authority: environment.authority,
      client_id: environment.clientId,
      redirect_uri: `${environment.clientRoot}/signin-callback`,
      // silent_redirect_uri: `${environment.clientRoot}/silent-callback.html`,
      post_logout_redirect_uri: `${environment.clientRoot}`,
      response_type: 'code',
      scope: environment.scope,
      loadUserInfo: true,
      userStore: new WebStorageStateStore({ store: window.localStorage }),
      monitorSession: false,
      // automaticSilentRenew: false,
    };

    console.log('Initializing auth service');

    this.userManager = new UserManager(settings);

    this.userManager.events.addUserSignedOut(() =>
      console.log('user signed out')
    );
  }

  public getUser(): Promise<User | null> {
    return this.userManager.getUser();
  }

  public signIn(): Promise<void> {
    return this.userManager.signinRedirect();
  }

  public renewToken(): Promise<User | null> {
    return this.userManager.signinSilent();
  }

  public signOut(): Promise<void> {
    return this.userManager.signoutRedirect();
  }

  public signinRedirectCallback() {
    return this.userManager.signinRedirectCallback();
  }

  public getAccessToken() {
    return this.user?.access_token ?? '';
  }

  public isSignedIn(): boolean {
    return !!(this.user && this.user.access_token && !this.user.expired);
  }

  public signinSilentCallback() {
    this.userManager.signinSilentCallback();
  }
}
