import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { PostEditComponent } from './components/post-edit/post-edit.component';
import { PostListComponent } from './components/post-list/post-list.component';

const routes: Routes = [
  {path: '', component: PostListComponent},
  {path: 'posts/:id', component: PostEditComponent},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
