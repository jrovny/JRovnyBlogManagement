import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from 'src/app/core/auth.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss'],
})
export class HomeComponent implements OnInit {
  sidenavOpened = true;

  constructor(private authService: AuthService, private router: Router) {}

  ngOnInit(): void {
    console.log('Home page ngOnInit');
    this.authService.getUser().then((user) => {
      if (user) {
        console.log('Home page getting user');
        this.authService.user = user;
      }
    });
  }

  signIn() {
    this.authService.signIn();
  }
}
