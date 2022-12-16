import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ActivityCreateRequest } from '../models/activity-create-request';
import { Activity } from '../models/activity';

@Injectable({
  providedIn: 'root'
})
export class ActivityService {

  private baseUrl = 'https://localhost:7244/api/administration';

  constructor(private httpClient: HttpClient) { }

  createActivity(request: ActivityCreateRequest): Observable<Activity> {
    return this.httpClient.post<Activity>(this.baseUrl + '/activities', request);
  }
}
