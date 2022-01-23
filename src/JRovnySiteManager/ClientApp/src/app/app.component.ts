import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  dataSource = [{
    title: 'Test',
    slug: 'slug'
  }];
  displayedColumns = ['title', 'slug'];
}
