import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
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

  constructor(private authService: AuthService, private router: Router) {}

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

  navigateToHomePage() {
    this.router.navigate(['/']);
  }
}
