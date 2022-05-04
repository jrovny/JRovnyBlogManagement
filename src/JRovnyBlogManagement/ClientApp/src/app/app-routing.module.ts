import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { MsalGuard } from '@azure/msal-angular';
import { BrowserUtils } from '@azure/msal-browser';
import { HomeComponent } from './components/home/home.component';
import { PostEditComponent } from './components/post-edit/post-edit.component';
import { PostListComponent } from './components/post-list/post-list.component';

const routes: Routes = [
  {
    path: '',
    component: HomeComponent,
    canActivate: [MsalGuard],
    children: [
      { path: 'posts', component: PostListComponent },
      { path: 'posts/:id', component: PostEditComponent },
    ],
  },
];

@NgModule({
  imports: [
    RouterModule.forRoot(routes, {
      // Don't perform initial navigation in iframes or popups
      initialNavigation:
        !BrowserUtils.isInIframe() && !BrowserUtils.isInPopup()
          ? 'enabled'
          : 'disabled', // Remove this line to use Angular Universal
    }),
  ],
  exports: [RouterModule],
})
export class AppRoutingModule {}
