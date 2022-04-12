import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './components/home/home.component';
import { PostEditComponent } from './components/post-edit/post-edit.component';
import { PostListComponent } from './components/post-list/post-list.component';
import { SigninCallbackComponent } from './components/signin-callback/signin-callback.component';
import { SilentCallbackComponent } from './components/silent-callback/silent-callback.component';
import { AuthGuard } from './core/guards/auth.guard';

const routes: Routes = [
  // { path: '', component: HomeComponent },
  {
    path: '',
    component: HomeComponent,
    canActivate: [AuthGuard],
    children: [
      { path: 'signin-callback', component: SigninCallbackComponent },
      { path: 'silent-callback.html', component: SilentCallbackComponent },
      { path: 'posts', component: PostListComponent },
      { path: 'posts/:id', component: PostEditComponent },
    ],
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
