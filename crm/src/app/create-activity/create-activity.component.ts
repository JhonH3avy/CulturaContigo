import { Component } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { first } from 'rxjs/operators';
import { ActivityCreateRequest } from '../models/activity-create-request';
import { ActivityService } from '../services/activity.service';
import { MatDialog } from '@angular/material/dialog';
import { InformationDialogComponent } from '../utils/information-dialog/information-dialog.component';

@Component({
  selector: 'app-create-activity',
  templateUrl: './create-activity.component.html',
  styleUrls: ['./create-activity.component.css']
})
export class CreateActivityComponent {
  activityForm = new FormGroup({
    name: new FormControl<string>('', Validators.required),
    details: new FormControl<string>('', Validators.required),
    place: new FormControl<string>(''),
    scheduledDate: new FormControl(null),
    isAllDayLong: new FormControl<boolean>(true),
    scheduledTime: new FormControl<string>(''),
    hasLimitedCapacity: new FormControl<boolean>(false),
    capacity: new FormControl<number>(0),
    requiresTicket: new FormControl<boolean>(false),
    ticketPrice: new FormControl<number>(0),
    imageUrl: new FormControl<string>('')
  });

  constructor(
    private activityService: ActivityService,
    private dialog: MatDialog
  ) {}

  get name(): FormControl<string> { return this.activityForm.get('name') as FormControl<string>; }
  get details(): FormControl<string> { return this.activityForm.get('details') as FormControl<string>; }
  get place(): FormControl<string> { return this.activityForm.get('place') as FormControl<string>; }
  get scheduledDate(): FormControl { return this.activityForm.get('scheduledDate') as FormControl; }
  get isAllDayLong(): FormControl<boolean> { return this.activityForm.get('isAllDayLong') as FormControl<boolean>; }
  get scheduledTime(): FormControl<string> { return this.activityForm.get('scheduledTime') as FormControl<string>; }
  get hasLimitedCapacity(): FormControl<boolean> { return this.activityForm.get('hasLimitedCapacity') as FormControl<boolean>; }
  get capacity(): FormControl<number> { return this.activityForm.get('capacity') as FormControl<number>; }
  get requiresTicket(): FormControl<boolean> { return this.activityForm.get('requiresTicket') as FormControl<boolean>; }
  get ticketPrice(): FormControl<number> { return this.activityForm.get('ticketPrice') as FormControl<number>; }
  get imageUrl(): FormControl<string> { return this.activityForm.get('imageUrl') as FormControl<string>; }

  onSubmit(): void {
    const scheduledDateTime = this.scheduledDate.value as Date;
    if (!this.isAllDayLong.value && scheduledDateTime) {
      const hourAndMinute = this.scheduledTime.value;
      const hourAndMinuteValues = hourAndMinute.split(':');
      const hour = Number.parseInt(hourAndMinuteValues[0]);
      const minute = Number.parseInt(hourAndMinuteValues[1]);
      scheduledDateTime.setHours(hour);
      scheduledDateTime.setMinutes(minute);
    }

    let request = {
      name: this.name.value,
      details: this.details.value,
      place: this.place.value ? this.place.value : null,
      scheduledDateTime: scheduledDateTime.toISOString(),
      imageUrl: this.imageUrl.value ? this.imageUrl.value : null,
      ticketPrice: this.requiresTicket.value ? this.ticketPrice.value : null,
      capacity: this.hasLimitedCapacity.value ? this.capacity.value : null
    } as ActivityCreateRequest;

    this.activityService.createActivity(request).pipe(first()).subscribe(activity => {
      this.showActivityCreationConfirmation(activity.id);
      this.name.reset('');
      this.details.reset('');
      this.place.reset('');
      this.scheduledDate.reset('');
      this.isAllDayLong.reset(true);
      this.scheduledTime.reset('');
      this.hasLimitedCapacity.reset(false);
      this.capacity.reset(0);
      this.requiresTicket.reset(false);
      this.ticketPrice.reset(0);
      this.imageUrl.reset('');
    });
  }

  showActivityCreationConfirmation(activityId: number): void {
    this.dialog.open(InformationDialogComponent, {
      width: '250px',
      data: { activityId },
    });
  }
}
