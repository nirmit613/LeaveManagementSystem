import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { EmployeeDashboardComponent } from './employee-dashboard/employee-dashboard.component';
import { EmployeeLeaveListComponent } from './employee-leave-list/employee-leave-list.component';

const routes: Routes = [
  {
    path:'',
    component:EmployeeDashboardComponent,
    children:[
      {path:'empLeavelist',component:EmployeeLeaveListComponent}
    ]
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class EmployeeRoutingModule { }
