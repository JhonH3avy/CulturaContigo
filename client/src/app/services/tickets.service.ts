import { Ticket } from './../models/ticket';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { TicketCreateRequest } from '../models/ticket-create-request';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class TicketsService {

  private baseUrl = 'https://localhost:7244/api';

  constructor(
    private httpClient: HttpClient
  ) { }

  createTicket(ticketCreateRequest: TicketCreateRequest): Observable<Ticket> {
    return this.httpClient.post<Ticket>(`${this.baseUrl}/ticket`, ticketCreateRequest);
  }
}
