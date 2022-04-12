import { Component, OnInit } from '@angular/core';
import { UserManager } from 'oidc-client-ts';
import { AuthService } from 'src/app/core/auth.service';

@Component({
  selector: 'app-silent-callback',
  templateUrl: './silent-callback.component.html',
  styleUrls: ['./silent-callback.component.scss'],
})
export class SilentCallbackComponent implements OnInit {
  constructor(private authService: AuthService) {}

  // var mgr = new oidc.UserManager({ response_mode: 'query' });
  // mgr.signinSilentCallback().catch(error => {
  //   console.error(error);
  // });

  ngOnInit(): void {
    this.authService.userManager
      .signinSilentCallback()
      .catch((err) => console.log(err));
  }
}
