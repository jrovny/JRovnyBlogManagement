import { Component, OnInit } from '@angular/core';
import { MsalService } from '@azure/msal-angular';
import { User } from 'oidc-client-ts';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.scss'],
})
export class NavbarComponent implements OnInit {
  sidenavOpened = true;
  user: User | null;
  loginDisplay = false;
  claims: any;

  constructor(private authService: MsalService) {}

  ngOnInit(): void {
    this.setLoginDisplay();
    this.claims = this.authService.instance.getActiveAccount()?.idTokenClaims;
    console.log(this.claims);
  }

  toggleSidenav() {
    this.sidenavOpened = !this.sidenavOpened;
  }

  signOut() {
    this.authService.logoutRedirect();
  }

  setLoginDisplay() {
    this.loginDisplay = this.authService.instance.getAllAccounts().length > 0;
  }
}
