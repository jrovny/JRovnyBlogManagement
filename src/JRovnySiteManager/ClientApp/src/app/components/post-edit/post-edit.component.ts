import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { MatDialog } from '@angular/material/dialog';
import { ActivatedRoute } from '@angular/router';
import { PostEdit } from 'src/app/models/post-edit';
import { PostsService } from 'src/app/services/posts.service';
import { ImageListComponent } from '../image-list/image-list.component';

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
  id: number = 0;

  constructor(
    private postService: PostsService,
    private route: ActivatedRoute,
    private fb: FormBuilder,
    private dialog: MatDialog
  ) {}

  ngOnInit(): void {
    this.id = Number(this.route.snapshot.paramMap.get('id'));

    this.postService.getPostById(this.id).subscribe((post) => {
      this.form.setValue({
        title: post.title,
        content: post.content,
        image: post.image,
        slug: post.slug,
        published: post.published,
      });
    });
  }

  getContentHtml() {
    return this.form.get('content')?.value;
  }

  getImageSrc() {
    return this.form.get('image')?.value;
  }

  openImageSelectDialog() {
    this.dialog.open(ImageListComponent);
  }

  save() {
    const formModel = this.form.value;
    const post: PostEdit = {
      postId: this.id,
      title: formModel.title,
      slug: formModel.slug,
      createdDate: new Date(2022, 1, 1),
      content: formModel.content,
      image: formModel.image,
      published: formModel.published,
      publishedDate: formModel.publishedDate,
    };

    this.postService.savePost(post);
  }
}
