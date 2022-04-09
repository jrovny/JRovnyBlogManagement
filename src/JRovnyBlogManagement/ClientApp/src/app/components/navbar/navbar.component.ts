import { Component, OnInit } from '@angular/core';
import { User } from 'oidc-client-ts';
import { AuthService } from 'src/app/core/auth.service';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.scss'],
})
export class NavbarComponent implements OnInit {
  sidenavOpened = true;
  user: User | null;

  constructor(private authService: AuthService) {}

  ngOnInit(): void {}

  toggleSidenav() {
    this.sidenavOpened = !this.sidenavOpened;
  }

  signIn() {
    this.authService.signIn();
  }

  signOut() {
    this.authService.signOut();
  }

  getUser() {
    return this.authService.user;
  }

  isSignedIn() {
    return this.authService.isSignedIn();
  }
}
