import { Component, OnInit } from '@angular/core';
import { AuthService } from 'src/app/core/auth.service';

@Component({
  selector: 'app-shell',
  templateUrl: './shell.component.html',
  styleUrls: ['./shell.component.scss'],
})
export class ShellComponent implements OnInit {
  sidenavOpened = true;

  constructor(private authService: AuthService) {}

  ngOnInit(): void {
    // this.authService.getUser().then((user) => {
    //   console.log('Shell component called');
    //   console.log(user);
    //   this.authService.user = user;
    // });
  }
}
