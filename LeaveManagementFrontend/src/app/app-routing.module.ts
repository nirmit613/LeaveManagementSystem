import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  {
    path:'',
    redirectTo:'auth/login',
    pathMatch:'full'
  },
  {
    
    path: 'auth',
    loadChildren: () =>
      import('./authentication/authentication.module').then(
        (m) => m.AuthenticationModule
      ),
  }
  ,
  {
    path: 'admin',
    loadChildren: () => import('./admin/admin.module').then(m => m.AdminModule),
  },
  {
    path: 'employee',
    loadChildren: () => import('./employee/employee.module').then(m => m.EmployeeModule),
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
