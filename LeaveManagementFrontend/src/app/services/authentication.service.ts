import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { environment as env } from 'src/environments/environment.development';
import { ILogin } from '../interfaces/login';
import { IUser } from '../interfaces/user';

@Injectable({
  providedIn: 'root'
})
export class AuthenticationService {

  private url: string = env.baseUrl;
  constructor(private http: HttpClient,private router:Router) {}
  public login(credentials: ILogin) {
    return this.http.post(this.url + 'login', credentials);
  }

  public signUp(userData: IUser) {
    let userApi = `${env.baseUrl}users/user`;
    return this.http.post(userApi, userData);
  }

  public getUserRole() {
    const userDataString = localStorage.getItem('UserData');
    if (userDataString) {
      const userData = JSON.parse(userDataString);
      return userData.role;
    }
  }
  isAuthenticated() {
    const data = localStorage.getItem('UserData');
    return !!data;

  }
  logout() {
    localStorage.removeItem('UserData'); 
  }
}
