import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from 'src/app/core/auth.service';

@Component({
  selector: 'app-signin-callback',
  templateUrl: './signin-callback.component.html',
  styleUrls: ['./signin-callback.component.scss'],
})
export class SigninCallbackComponent implements OnInit {
  constructor(private authService: AuthService, private router: Router) {}

  async ngOnInit(): Promise<void> {
    await this.authService.userManager.signinRedirectCallback().then((user) => {
      console.log('signinCallback() called', user);
      this.router.navigate(['']);
    });
  }
}
