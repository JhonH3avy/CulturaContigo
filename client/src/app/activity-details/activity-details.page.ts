import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Subscription } from 'rxjs';
import { Activity } from '../models/activity';
import { ActivitiesService } from '../services/activities.service';

@Component({
  selector: 'app-activity-details',
  templateUrl: './activity-details.page.html',
  styleUrls: ['./activity-details.page.scss'],
})
export class ActivityDetailsPage implements OnInit {

  activity!: Activity;
  subscriptions = new Subscription();

  constructor(
    private activatedRoute: ActivatedRoute,
    private activitiesService: ActivitiesService
  ) { }

  ngOnInit() {
    this.subscriptions.add(this.activatedRoute.paramMap.subscribe(
      params => {
        const activityId = params.get('activityId') || '';
        this.activitiesService.getActivity(activityId).subscribe(activity => this.activity = activity);
      }
    ));
  }

}
