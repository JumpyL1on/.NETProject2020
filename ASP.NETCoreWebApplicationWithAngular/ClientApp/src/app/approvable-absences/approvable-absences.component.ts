import { Component, Inject, OnInit } from '@angular/core';
import { Observable } from "rxjs";
import { HttpClient } from "@angular/common/http";
import { AbsenceType } from "../absence-type.enum";
import { Absence } from "../absence";

@Component({
  selector: 'app-approvable-absences',
  templateUrl: './approvable-absences.component.html',
  styleUrls: ['./approvable-absences.component.css']
})

export class ApprovableAbsencesComponent implements OnInit {
  approvableAbsences: Observable<Absence[]>;
  absenceTypes: string[] = [
    "SickDay",
    "SickLeave",
    "ApprovedSickLeave",
    "UnPaidVacation",
    "ApprovedUnPaidVacation",
    "PaidVacation",
    "ApprovedPaidVacation"
  ];

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) {
    this.approvableAbsences = this.http.get<Absence[]>(this.baseUrl + 'api/Absence/approvable');
  }

  ngOnInit() {
  }

  Approve(absence: Absence): void {
    let updateAbsenceCommand = <UpdateAbsenceCommand>{
      id: absence.id,
      absenceType: absence.absenceType
    }
    this.http
      .put<Absence>(this.baseUrl + "api/Absence", updateAbsenceCommand)
      .subscribe();
  }

  Disapprove(absence: Absence): void {
    this.http
      .delete(this.baseUrl + "api/Absence/" + absence.id)
      .subscribe();
  }
}

interface UpdateAbsenceCommand {
  id: number;
  absenceType: AbsenceType
}
