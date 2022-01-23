import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class PostsService {

  constructor() { }

  getPosts() {
    return [
      {
        postId: 1,
        title: 'Test',
        slug: 'Test'
      }
    ];
  }
}
