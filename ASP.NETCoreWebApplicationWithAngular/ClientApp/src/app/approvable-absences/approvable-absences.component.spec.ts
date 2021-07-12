import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ApprovableAbsencesComponent } from './approvable-absences.component';

describe('AbsencesWithApprovalComponent', () => {
  let component: ApprovableAbsencesComponent;
  let fixture: ComponentFixture<ApprovableAbsencesComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ApprovableAbsencesComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ApprovableAbsencesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
