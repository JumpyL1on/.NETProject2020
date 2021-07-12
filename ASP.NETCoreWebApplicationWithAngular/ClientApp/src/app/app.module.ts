import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { ApiAuthorizationModule } from 'src/api-authorization/api-authorization.module';
import { AuthorizeGuard } from 'src/api-authorization/authorize.guard';
import { AuthorizeInterceptor } from 'src/api-authorization/authorize.interceptor';
import { AdminPanelComponent } from './admin-panel/admin-panel.component';
import { ApprovableAbsencesComponent } from './approvable-absences/approvable-absences.component';
import { CalendarComponent } from './calendar/calendar.component';
import {PDFModule, SchedulerModule} from '@progress/kendo-angular-scheduler';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { RecommendationsComponent } from './recommendations/recommendations.component';
import { EmployeeDashboardComponent } from './employee-dashboard/employee-dashboard.component';
import { TrackableAbsencesComponent } from './trackable-absences/trackable-absences.component';
import { AdminResponsibilityComponent } from './admin-responsibility/admin-responsibility.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    AdminPanelComponent,
    ApprovableAbsencesComponent,
    CalendarComponent,
    RecommendationsComponent,
    EmployeeDashboardComponent,
    TrackableAbsencesComponent,
    AdminResponsibilityComponent,
  ],
  imports: [
    BrowserModule.withServerTransition({appId: 'ng-cli-universal'}),
    HttpClientModule,
    FormsModule,
    ApiAuthorizationModule,
    RouterModule.forRoot([
      {path: '', component: HomeComponent, pathMatch: 'full'},
      {path: 'adminPanel', component: AdminPanelComponent, canActivate: [AuthorizeGuard]},
      {path: 'employeeDashboard', component: EmployeeDashboardComponent, canActivate: [AuthorizeGuard]}
    ]),
    SchedulerModule,
    BrowserAnimationsModule,
    PDFModule
  ],
  providers: [
    {provide: HTTP_INTERCEPTORS, useClass: AuthorizeInterceptor, multi: true}
  ],
  bootstrap: [AppComponent]
})

export class AppModule { }
