import { NgModule } from '@angular/core';
import { PreloadAllModules, RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  {
    path: 'home',
    loadChildren: () => import('./home/home.module').then( m => m.HomePageModule)
  },
  {
    path: '',
    redirectTo: 'home',
    pathMatch: 'full'
  },
  {
    path: 'activity-details',
    loadChildren: () => import('./activity-details/activity-details.module').then( m => m.ActivityDetailsPageModule)
  },
  {
    path: 'ticket-generator',
    loadChildren: () => import('./ticket-generator/ticket-generator.module').then( m => m.TicketGeneratorPageModule)
  },
  {
    path: 'coming-soon-activities',
    loadChildren: () => import('./coming-soon-activities/coming-soon-activities.module').then( m => m.ComingSoonActivitiesPageModule)
  },
  {
    path: 'contact',
    loadChildren: () => import('./contact/contact.module').then( m => m.ContactPageModule)
  },
];

@NgModule({
  imports: [
    RouterModule.forRoot(routes, { preloadingStrategy: PreloadAllModules })
  ],
  exports: [RouterModule]
})
export class AppRoutingModule { }
