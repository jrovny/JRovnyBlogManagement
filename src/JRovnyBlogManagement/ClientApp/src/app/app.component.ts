import { Component, OnInit } from '@angular/core';
import { User } from 'oidc-client-ts';
import { AuthService } from './core/auth.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss'],
})
export class AppComponent implements OnInit {
  sidenavOpened = true;
  user: User | null;

  constructor(private authService: AuthService) {}

  ngOnInit(): void {
    console.log('ngOnInit');
    this.authService.getUser().then((user) => {
      console.log('authService.getUser()', user);
      this.user = user;
    });
  }

  toggleSidenav() {
    this.sidenavOpened = !this.sidenavOpened;
  }

  signIn() {
    this.authService.signIn();
  }

  signOut() {
    this.authService.signOut();
  }
}
