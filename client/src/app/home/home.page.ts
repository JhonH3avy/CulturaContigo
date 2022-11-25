import { Component, OnDestroy, OnInit } from '@angular/core';
import { Subscription } from 'rxjs';
import { Activity } from '../models/activity';
import { PaginationOptions } from '../models/pagination-options';
import { ActivitiesService } from '../services/activities.service';

@Component({
  selector: 'app-home',
  templateUrl: 'home.page.html',
  styleUrls: ['home.page.scss'],
})
export class HomePage implements OnInit, OnDestroy {

  nowActivities: Activity[] = [];
  soonActivities: Activity[] = [];

  subscriptions: Subscription = new Subscription();

  constructor(private activitiesService: ActivitiesService) {}

  ngOnInit(): void {
    const defaultPaginationOptions: PaginationOptions = {
      page: 0,
      size: 100
    };
    this.subscriptions.add(this.activitiesService.getNowActivities(defaultPaginationOptions).subscribe(activities => this.nowActivities = activities));
    this.subscriptions.add(this.activitiesService.getSoonActivities(defaultPaginationOptions).subscribe(activities => this.soonActivities = activities));
  }

  ngOnDestroy(): void {
    this.subscriptions.unsubscribe();
  }
}
