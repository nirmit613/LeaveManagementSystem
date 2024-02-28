import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment.development';
import { ILeave } from '../interfaces/leave';
import { DatePipe } from '@angular/common';

@Injectable({
  providedIn: 'root'
})
export class LeaveService {

  constructor(private http: HttpClient,private router:Router,private datePipe:DatePipe) {}

  public getAllLeaves():Observable<any>{
    return this.http.get<any>(`${environment.baseUrl}leaves/Leaves`);
  }
  public getLeaveByUserId(userId:number):Observable<any>{
    return this.http.get<any>(`${environment.baseUrl}leaves/userId?userId=${userId}`);
  }
  public UpdateLeave(leave:any): Observable<any>{
    return this.http.put<any>(`${environment.baseUrl}leaves`,leave);
  }
  public AddLeave(leave:any):Observable<any>{
    return this.http.post(`${environment.baseUrl}leaves/leave`,leave);
  }
  downloadAllLeaves(): Observable<Blob> {
    return this.http.get(`${environment.baseUrl}leaves/CSV`, { responseType: 'blob' });
  }
  convertToCSV(data: ILeave[]): string {
    const headers = ['EmployeeName', 'StartDate', 'EndDate', 'Reason' , 'DateOfRequest'];
    const csvData = [headers.join(',')];

    for (const leave of data) {
      const startDate = this.datePipe.transform(leave.startDate, 'yyyy-MM-dd');
       const endDate = this.datePipe.transform(leave.endDate, 'yyyy-MM-dd');
      const employeeName = `${leave.user.firstName}`;
      const row = [employeeName, startDate , endDate, leave.reasonForLeave , leave.dateOfRequest];
      csvData.push(row.join(','));
    }

    return csvData.join('\n');
  }
}
