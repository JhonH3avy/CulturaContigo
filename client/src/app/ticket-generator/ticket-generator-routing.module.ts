import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { TicketGeneratorPage } from './ticket-generator.page';

const routes: Routes = [
  {
    path: ':activityId',
    component: TicketGeneratorPage
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class TicketGeneratorPageRoutingModule {}
