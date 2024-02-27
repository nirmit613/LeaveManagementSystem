import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AuthenticationRoutingModule } from './authentication-routing.module';
import { LoginComponent } from './login/login.component';
import { SignupComponent } from './signup/signup.component';
import { HttpClientModule } from '@angular/common/http';
import { ReactiveFormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { AuthWrapperComponent } from './auth-wrapper/auth-wrapper.component';


@NgModule({
  declarations: [
    LoginComponent,
    SignupComponent,
    AuthWrapperComponent
  ],
  imports: [
    CommonModule,
    AuthenticationRoutingModule,
    HttpClientModule,
    ReactiveFormsModule,
    RouterModule
  ],
  exports:[AuthWrapperComponent]
})
export class AuthenticationModule { }
