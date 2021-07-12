import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AdminResponsibilityComponent } from './admin-responsibility.component';

describe('AdminResponsibilityComponent', () => {
  let component: AdminResponsibilityComponent;
  let fixture: ComponentFixture<AdminResponsibilityComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AdminResponsibilityComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AdminResponsibilityComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
