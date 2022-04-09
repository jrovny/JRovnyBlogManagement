import { Component, OnInit } from '@angular/core';
import { Post } from 'src/app/models/post';
import { PostsService } from 'src/app/services/posts.service';
import { AuthService } from 'src/app/core/auth.service';

@Component({
  selector: 'app-post-list',
  templateUrl: './post-list.component.html',
  styleUrls: ['./post-list.component.scss'],
})
export class PostListComponent implements OnInit {
  dataSource: Post[] = [];
  displayedColumns = ['title', 'slug', 'createdDate', 'edit'];

  constructor(
    private postsService: PostsService,
    private authService: AuthService
  ) {}

  ngOnInit(): void {
    this.authService.getUser().then((user) => {
      this.authService.getUser().then((user) => {
        this.authService.user = user;
      });
    });
    this.postsService
      .getPosts()
      .subscribe((posts) => (this.dataSource = posts));
  }
}
