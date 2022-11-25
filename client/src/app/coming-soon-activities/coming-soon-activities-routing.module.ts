import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { ComingSoonActivitiesPage } from './coming-soon-activities.page';

const routes: Routes = [
  {
    path: '',
    component: ComingSoonActivitiesPage
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class ComingSoonActivitiesPageRoutingModule {}
