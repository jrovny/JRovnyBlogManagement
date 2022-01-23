import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { PostsService } from 'src/app/services/posts.service';

@Component({
  selector: 'app-post-edit',
  templateUrl: './post-edit.component.html',
  styleUrls: ['./post-edit.component.scss']
})
export class PostEditComponent implements OnInit {
  post: any;

  constructor(private postService: PostsService, private route: ActivatedRoute) { }

  ngOnInit(): void {
    const id = Number(this.route.snapshot.paramMap.get('id'));

    this.postService.getPostById(id).subscribe(post => {
      console.log(post);
      this.post = post
    });
  }
}
