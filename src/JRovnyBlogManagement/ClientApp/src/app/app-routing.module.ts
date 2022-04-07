import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { PostEditComponent } from './components/post-edit/post-edit.component';
import { PostListComponent } from './components/post-list/post-list.component';
import { SigninCallbackComponent } from './components/signin-callback/signin-callback.component';

const routes: Routes = [
  { path: '', component: PostListComponent },
  { path: 'posts/:id', component: PostEditComponent },
  { path: 'signin-callback.html', component: SigninCallbackComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
