import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { IonicModule } from '@ionic/angular';

import { TicketGeneratorPageRoutingModule } from './ticket-generator-routing.module';

import { TicketGeneratorPage } from './ticket-generator.page';
import { RouterModule } from '@angular/router';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    IonicModule,
    TicketGeneratorPageRoutingModule,
    RouterModule
  ],
  declarations: [TicketGeneratorPage]
})
export class TicketGeneratorPageModule {}
