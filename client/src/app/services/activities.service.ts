import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { PaginationOptions } from '../models/pagination-options';
import { Activity } from '../models/activity';

@Injectable({
  providedIn: 'root'
})
export class ActivitiesService {

  private baseUrl = 'https://localhost:7244/api';

  constructor(private httpClient: HttpClient) { }

  getNowActivities(paginationOptions: PaginationOptions): Observable<Activity[]> {
    const params = this.convertPaginationOptionsToHttpParams(paginationOptions);
    return this.httpClient.get<Activity[]>(`${this.baseUrl}/activities/now`,{params});
  }

  getSoonActivities(paginationOptions: PaginationOptions): Observable<Activity[]> {
    const params = this.convertPaginationOptionsToHttpParams(paginationOptions);
    return this.httpClient.get<Activity[]>(`${this.baseUrl}/activities/soon`,{params});
  }

  getLateActivities(paginationOptions: PaginationOptions): Observable<Activity[]> {
    const params = this.convertPaginationOptionsToHttpParams(paginationOptions);
    return this.httpClient.get<Activity[]>(`${this.baseUrl}/activities/late`,{params});
  }

  getActivity(activityId: string | number): Observable<Activity> {
    return this.httpClient.get<Activity>(`${this.baseUrl}/activities/${activityId}`);
  }

  private convertPaginationOptionsToHttpParams = (paginationOptions: PaginationOptions): HttpParams => {
    const params = new HttpParams()
      .append('page', paginationOptions.page)
      .append('size', paginationOptions.size);
    return params;
  };
}
