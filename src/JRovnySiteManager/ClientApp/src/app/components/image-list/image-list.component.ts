import { Component, OnInit } from '@angular/core';
import { PostsService } from 'src/app/services/posts.service';

@Component({
  selector: 'app-image-list',
  templateUrl: './image-list.component.html',
  styleUrls: ['./image-list.component.scss'],
})
export class ImageListComponent implements OnInit {
  images: any;

  constructor(private postsService: PostsService) {}

  ngOnInit(): void {
    this.postsService.getImages().subscribe((list) => (this.images = list));
  }
}
