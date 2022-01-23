import { Component } from '@angular/core';
import { PostsService } from './services/posts.service';

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
  
  constructor(private postsService: PostsService) {
  }
}
