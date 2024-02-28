import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { NgToastService } from 'ng-angular-popup';
import { AuthenticationService } from 'src/app/services/authentication.service';

@Component({
  selector: 'app-employee-dashboard',
  templateUrl: './employee-dashboard.component.html',
  styleUrls: ['./employee-dashboard.component.scss']
})
export class EmployeeDashboardComponent {
  userEmail!: string;
  userRole!:string;
  constructor(private authService: AuthenticationService,private router:Router,private toast:NgToastService) {}
  ngOnInit(): void {
    this.userRole = this.authService.getUserRole();
    const userData = localStorage.getItem('UserData');
    if (userData) {
      const user = JSON.parse(userData);
      this.userEmail = user.email;
    }
  }
  public isLoggedIn(): boolean {
    return this.authService.isAuthenticated();
  }
  public logout(): void {
    if (confirm('Are you sure you want to log out?')) {
      this.authService.logout(); 
      this.toast.success({detail:"Success Message", summary: "You have been logged out successfully!", duration: 3000});
      this.router.navigate(['/auth/login']);
    }
}
}
