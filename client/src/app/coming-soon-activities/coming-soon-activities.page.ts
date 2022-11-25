import { Component, OnDestroy, OnInit } from '@angular/core';
import { Subscription } from 'rxjs';
import { Activity } from '../models/activity';
import { PaginationOptions } from '../models/pagination-options';
import { ActivitiesService } from '../services/activities.service';

@Component({
  selector: 'app-coming-soon-activities',
  templateUrl: './coming-soon-activities.page.html',
  styleUrls: ['./coming-soon-activities.page.scss'],
})
export class ComingSoonActivitiesPage implements OnInit, OnDestroy {

  lateActivities: Activity[] = [];

  subscriptions: Subscription = new Subscription();

  constructor(private activitiesService: ActivitiesService) {}

  ngOnInit(): void {
    const defaultPaginationOptions: PaginationOptions = {
      page: 0,
      size: 100
    };
    this.subscriptions.add(this.activitiesService.getLateActivities(defaultPaginationOptions).subscribe(activities => this.lateActivities = activities));
  }

  ngOnDestroy(): void {
    this.subscriptions.unsubscribe();
  }
}
