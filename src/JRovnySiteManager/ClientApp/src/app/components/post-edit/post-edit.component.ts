import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { PostsService } from 'src/app/services/posts.service';

@Component({
  selector: 'app-post-edit',
  templateUrl: './post-edit.component.html',
  styleUrls: ['./post-edit.component.scss'],
})
export class PostEditComponent implements OnInit {
  form = this.fb.group({
    title: ['', Validators.required],
    content: [''],
    image: [''],
    slug: [''],
    published: [false, Validators.required],
  });

  constructor(
    private postService: PostsService,
    private route: ActivatedRoute,
    private fb: FormBuilder
  ) {}

  ngOnInit(): void {
    const id = Number(this.route.snapshot.paramMap.get('id'));

    this.postService.getPostById(id).subscribe((post) => {
      this.form.setValue({
        title: post.title,
        content: post.content,
        image: post.image,
        slug: post.slug,
        published: post.published,
      });
    });

    // console.log(this.form.value);
  }

  getContentHtml() {
    return this.form.get('content')?.value;
  }
}
