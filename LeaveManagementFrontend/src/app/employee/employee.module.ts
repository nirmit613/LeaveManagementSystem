import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { EmployeeRoutingModule } from './employee-routing.module';
import { EmployeeDashboardComponent } from './employee-dashboard/employee-dashboard.component';
import { EmployeeLeaveListComponent } from './employee-leave-list/employee-leave-list.component';
import { AddLeaveComponent } from './add-leave/add-leave.component';
import { ReactiveFormsModule } from '@angular/forms';


@NgModule({
  declarations: [
    EmployeeDashboardComponent,
    EmployeeLeaveListComponent,
    AddLeaveComponent
  ],
  imports: [
    CommonModule,
    EmployeeRoutingModule,
    ReactiveFormsModule
  ]
})
export class EmployeeModule { }
