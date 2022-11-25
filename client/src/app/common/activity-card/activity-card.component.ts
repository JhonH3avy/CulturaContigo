import { Component, HostListener, Input } from '@angular/core';
import { Router } from '@angular/router';
import { Activity } from 'src/app/models/activity';

@Component({
  selector: 'app-activity-card',
  templateUrl: './activity-card.component.html',
  styleUrls: ['./activity-card.component.scss'],
})
export class ActivityCardComponent {

  @Input() activity!: Activity;

  constructor(private router: Router) { }

  @HostListener("click") onClick(){
    this.router.navigate(['/activity-details/', this.activity.id]);
  }
}
