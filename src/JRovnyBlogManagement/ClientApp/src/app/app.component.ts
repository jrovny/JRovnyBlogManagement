import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss'],
})
export class AppComponent {
  sidenavOpened = true;

  constructor() {}

  toggleSidenav() {
    this.sidenavOpened = !this.sidenavOpened;
  }
}
