import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Post } from '../models/post';
import { PostEdit } from '../models/post-edit';

@Injectable({
  providedIn: 'root'
})
export class PostsService {

  constructor(private http: HttpClient) { }

  getPosts() {
    return this.http.get<Post[]>('/api/posts');
  }

  getPostById(id: number) {
    return this.http.get<PostEdit>('/api/posts/' + id);
  }
}
