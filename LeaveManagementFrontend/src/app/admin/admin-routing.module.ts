import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LeaveListsComponent } from './leave-lists/leave-lists.component';
import { AuthWrapperComponent } from '../authentication/auth-wrapper/auth-wrapper.component';

const routes: Routes = [
  {
    path:'',
    component:AuthWrapperComponent,
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
