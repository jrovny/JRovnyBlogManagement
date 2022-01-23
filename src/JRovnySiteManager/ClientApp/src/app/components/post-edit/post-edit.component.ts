import { Component, OnInit } from '@angular/core';
import { Post } from 'src/app/models/post';
import { PostsService } from 'src/app/services/posts.service';

@Component({
  selector: 'app-post-edit',
  templateUrl: './post-edit.component.html',
  styleUrls: ['./post-edit.component.scss']
})
export class PostEditComponent implements OnInit {
  post: any;

  constructor(private postService: PostsService) { }

  ngOnInit(): void {
    this.postService.getPostById(1).subscribe(post => {
      console.log(post);
      this.post = post
    });
  }
}
