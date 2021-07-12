import {Component, Inject, OnInit } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import { AuthorizeService } from "../../api-authorization/authorize.service";
import { map } from "rxjs/operators";
import { AbsenceType } from "../absence-type.enum";

@Component({
  selector: 'app-trackable-absences',
  templateUrl: './trackable-absences.component.html',
  styleUrls: ['./trackable-absences.component.css']
})

export class TrackableAbsencesComponent implements OnInit {
  sickDay: Date;
  sickLeaveStart: Date;
  sickLeaveEnd: Date;
  vacationStart: Date;
  vacationEnd: Date;
  isPaid: boolean = false;
  applicationUserUserName: string;

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string, private authorizeService: AuthorizeService) {
    this.authorizeService
      .getUser()
      .pipe(map(u => u && u.name))
      .subscribe(x => this.applicationUserUserName = x)
      .unsubscribe();
  }

  ngOnInit() {
  }

  approveSickDay(): void {
    this.http.post(this.baseUrl + "api/Absence",
      <CreateAbsenceCommand>{
        absenceType: AbsenceType.sickDay,
        applicationUserUserName: this.applicationUserUserName,
        start: this.sickDay,
        end: this.sickDay
      }).subscribe();
  }

  requestSickLeave(): void {
    this.http.post(this.baseUrl + "api/Absence",
      <CreateAbsenceCommand>{
        absenceType: AbsenceType.sickLeave,
        applicationUserUserName: this.applicationUserUserName,
        start: this.sickLeaveStart,
        end: this.sickLeaveEnd
      }).subscribe();
  }

  requestVacation(): void {
    this.http.post(this.baseUrl + "api/Absence",
      <CreateAbsenceCommand>{
        absenceType: AbsenceType.unPaidVacation,
        applicationUserUserName: this.applicationUserUserName,
        start: this.vacationStart,
        end: this.vacationEnd,
        isPaid: this.isPaid
      }).subscribe();
  }
}

interface CreateAbsenceCommand {
  absenceType: AbsenceType;
  applicationUserUserName: string;
  start: Date;
  end: Date;
  isPaid?: boolean;
}
