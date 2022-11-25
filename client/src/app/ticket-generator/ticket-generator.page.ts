import { Component, OnDestroy, OnInit, ViewChild } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { IonModal } from '@ionic/angular';
import { Subscription } from 'rxjs';
import { Ticket } from '../models/ticket';
import { TicketCreateRequest } from '../models/ticket-create-request';
import { TicketsService } from '../services/tickets.service';

@Component({
  selector: 'app-ticket-generator',
  templateUrl: './ticket-generator.page.html',
  styleUrls: ['./ticket-generator.page.scss'],
})
export class TicketGeneratorPage implements OnInit, OnDestroy {

  @ViewChild(IonModal) modal!: IonModal;

  ticketForm = new FormGroup({
    activityId: new FormControl<number>(0),
    typeOfId: new FormControl<string>(''),
    personalId: new FormControl<string>(''),
    numberOfTickets: new FormControl<number>(1, Validators.max(5)),
  })

  ticket!: Ticket;

  subscriptions = new Subscription();

  constructor(
    private activatedRoute: ActivatedRoute,
    private ticketsService: TicketsService,
    private router: Router
  ) { }

  get activityId(): FormControl<number> { return this.ticketForm.get('activityId') as FormControl<number>; }
  get typeOfId(): FormControl<string> { return this.ticketForm.get('typeOfId') as FormControl<string>; }
  get personalId(): FormControl<string> { return this.ticketForm.get('personalId') as FormControl<string>; }
  get numberOfTickets(): FormControl<number> { return this.ticketForm.get('numberOfTickets') as FormControl<number>; }

  ngOnDestroy(): void {
    this.subscriptions.unsubscribe();
  }

  ngOnInit() {
    this.subscriptions.add(this.activatedRoute.paramMap.subscribe(params => {
      const activityId = Number.parseInt(params.get('activityId') || '0');
      this.activityId.setValue(activityId);
    }));
  }

  onSubmit() {
    const request = {
      activityId: this.activityId.value,
      typeOfId: this.typeOfId.value,
      personalId: this.personalId.value,
      numberOfTickets: this.numberOfTickets.value
    } as TicketCreateRequest;

    this.ticketsService.createTicket(request).subscribe(ticket => {
      this.ticket = ticket;
      this.modal.isOpen = true;
    });
  }

  confirm() {
    this.modal.isOpen = false;
    this.router.navigate(['/activity-details/', this.activityId.value]);
  }
}
