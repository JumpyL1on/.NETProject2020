import { Component, Inject, OnInit } from '@angular/core';
import {Group, Resource, SchedulerEvent} from "@progress/kendo-angular-scheduler";
import { HttpClient } from "@angular/common/http";
import { Observable } from "rxjs";
import { Absence } from "../absence";
import { map } from "rxjs/operators";
import { AbsenceType } from "../absence-type.enum";

@Component({
  selector: 'app-calendar',
  templateUrl: './calendar.component.html',
  styleUrls: ['./calendar.component.css']
})

export class CalendarComponent implements OnInit {
  public date: Date = new Date();
  public selectedDate: Date = new Date(this.date.getFullYear(), this.date.getMonth(), this.date.getDate());
  public events: Observable<SchedulerEvent[]>;
  public resources: Observable<Resource[]>;
  public group: Group = {
    resources: ['Employees'],
    orientation: 'vertical'
  }

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) {
    this.resources = this.http.get<Resource[]>(this.baseUrl + 'api/ApplicationUser');
    this.events = this.http
      .get<Absence[]>(this.baseUrl + 'api/Absence')
      .pipe(map(absences =>
        absences.map(absence =>
          <SchedulerEvent>{
            id: absence.id,
            start: new Date(absence.start),
            end: new Date(absence.end),
            title: AbsenceType[absence.absenceType],
            employeeId: absence.applicationUserId
          })
      ))
  };

  ngOnInit() {
  }
}
