import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AdminRoutingModule } from './admin-routing.module';
import { LeaveListsComponent } from './leave-lists/leave-lists.component';
import { AdminDashboardComponent } from './admin-dashboard/admin-dashboard.component';
import { ReactiveFormsModule } from '@angular/forms';


@NgModule({
  declarations: [
    LeaveListsComponent,
    AdminDashboardComponent,
  ],
  imports: [
    CommonModule,
    AdminRoutingModule,
    ReactiveFormsModule
  ]
})
export class AdminModule { }
