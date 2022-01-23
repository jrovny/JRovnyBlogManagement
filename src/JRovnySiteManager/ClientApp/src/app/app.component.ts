import { Component, OnInit } from '@angular/core';
import { Post } from './models/post';
import { PostsService } from './services/posts.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {
  dataSource: Post[] = [];
  displayedColumns = ['title', 'slug'];
  
  constructor(private postsService: PostsService) {
  }

  ngOnInit(): void {
    this.postsService.getPosts().subscribe(posts => this.dataSource = posts);
  }
}
