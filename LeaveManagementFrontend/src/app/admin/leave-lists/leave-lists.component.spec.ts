import { ComponentFixture, TestBed } from '@angular/core/testing';

import { LeaveListsComponent } from './leave-lists.component';

describe('LeaveListsComponent', () => {
  let component: LeaveListsComponent;
  let fixture: ComponentFixture<LeaveListsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ LeaveListsComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(LeaveListsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
