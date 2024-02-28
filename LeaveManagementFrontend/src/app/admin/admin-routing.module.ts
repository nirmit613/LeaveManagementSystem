import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LeaveListsComponent } from './leave-lists/leave-lists.component';
import { AdminDashboardComponent } from './admin-dashboard/admin-dashboard.component';

const routes: Routes = [
  {
    path:'',
    component:AdminDashboardComponent,
    children:[
      {path:'Leave-list',component:LeaveListsComponent}
    ]
  },
  
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AdminRoutingModule { }
