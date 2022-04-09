import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './components/home/home.component';
import { PostEditComponent } from './components/post-edit/post-edit.component';
import { PostListComponent } from './components/post-list/post-list.component';
import { ShellComponent } from './components/shell/shell.component';
import { SigninCallbackComponent } from './components/signin-callback/signin-callback.component';
import { AuthGuard } from './core/guards/auth.guard';

const routes: Routes = [
  { path: '', component: HomeComponent },
  { path: 'signin-callback', component: SigninCallbackComponent },
  {
    path: 'admin',
    component: ShellComponent,
    canActivate: [AuthGuard],
    children: [
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
