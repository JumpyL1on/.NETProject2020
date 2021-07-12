import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { TrackableAbsencesComponent } from './trackable-absences.component';

describe('TrackableAbsencesComponent', () => {
  let component: TrackableAbsencesComponent;
  let fixture: ComponentFixture<TrackableAbsencesComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ TrackableAbsencesComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TrackableAbsencesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
