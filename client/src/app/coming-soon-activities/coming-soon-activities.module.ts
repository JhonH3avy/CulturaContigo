import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { IonicModule } from '@ionic/angular';

import { ComingSoonActivitiesPageRoutingModule } from './coming-soon-activities-routing.module';

import { ComingSoonActivitiesPage } from './coming-soon-activities.page';
import { CommonComponentsModule } from '../common/common-components.module';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    IonicModule,
    ComingSoonActivitiesPageRoutingModule,
    CommonComponentsModule
  ],
  declarations: [ComingSoonActivitiesPage]
})
export class ComingSoonActivitiesPageModule {}
