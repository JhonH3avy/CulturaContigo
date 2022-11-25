import { RouterModule } from '@angular/router';
import { NgModule } from '@angular/core';
import { IonicModule } from '@ionic/angular';
import { ActivityCardComponent } from './activity-card/activity-card.component';

import { MenuComponent } from './menu/menu.component';

@NgModule({
  imports: [
    IonicModule,
    RouterModule
  ],
  exports: [
    MenuComponent,
    ActivityCardComponent
  ],
  declarations: [
    MenuComponent,
    ActivityCardComponent
  ]
})
export class CommonComponentsModule { }
