import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CreateActivityComponent } from './create-activity/create-activity.component';

const routes: Routes = [{
  path: 'activity',
  component: CreateActivityComponent
},{
  path: '',
  redirectTo: '/activity',
  pathMatch: 'full'
}];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
