import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { NgToastService } from 'ng-angular-popup';
import { AuthenticationService } from 'src/app/services/authentication.service';

@Component({
  selector: 'app-admin-dashboard',
  templateUrl: './admin-dashboard.component.html',
  styleUrls: ['./admin-dashboard.component.scss']
})
export class AdminDashboardComponent {


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