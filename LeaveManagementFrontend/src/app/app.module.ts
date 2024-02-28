import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NgToastModule } from 'ng-angular-popup';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { PageNotFoundComponent } from './page-not-found/page-not-found.component';
import { HttpClientModule } from '@angular/common/http';
import {MatDialogModule } from '@angular/material/dialog';
import { DatePipe } from '@angular/common';

@NgModule({
  declarations: [
    AppComponent,
    PageNotFoundComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    NgToastModule,
    BrowserAnimationsModule,
    HttpClientModule,
    MatDialogModule,
  
  ],
  providers: [DatePipe],
  bootstrap: [AppComponent]
})
export class AppModule { }
