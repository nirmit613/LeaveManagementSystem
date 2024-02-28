import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { NgToastService } from 'ng-angular-popup';
import { ILeave } from 'src/app/interfaces/leave';
import { LeaveService } from 'src/app/services/leave.service';

@Component({
  selector: 'app-leave-lists',
  templateUrl: './leave-lists.component.html',
  styleUrls: ['./leave-lists.component.scss']
})
export class LeaveListsComponent {

  public leaveList!:ILeave[];
  constructor(private leaveService:LeaveService,private toast:NgToastService) {}
  ngOnInit():void{
this.getAllLeaves();
  }
  public getAllLeaves():void{
    this.leaveService.getAllLeaves().subscribe({
      next:(res)=>{
        console.log(res);
        this.leaveList = res.data;
      },
      error: (error) => {
        this.toast.error({detail:"Error Message",summary:"Some error occur while fetching the data!!",duration:3000})
      },
    })
  }
  public ApprovedLeave(leave: any): void {
    leave.status = 'Approved'; 
    this.leaveService.UpdateLeave(leave).subscribe(
      response => {
        console.log('Leave Approved successfully:', response);
        this.toast.success({detail:"Success Message",summary:"Your have approved leave!!",duration:3000});
        this.getAllLeaves();
      },
      (error) => {
        console.error('Error cancelling leave:', error);
      }
    );
  }
  public RejectLeave(leave: any): void {
    leave.status = 'Rejected'; 
    this.leaveService.UpdateLeave(leave).subscribe(
      response => {
        console.log('Leave Rejected:', response);
        this.toast.success({detail:"Success Message",summary:"Your have Rejected leave!!",duration:3000});
        this.getAllLeaves();
      },
      (error) => {
        console.error('Error cancelling leave:', error);
      }
    );
  }
  public calculateTotalDays(startDate: Date, endDate: Date): number {
    const oneDay = 24 * 60 * 60 * 1000; 
    const start = new Date(startDate);
    const end = new Date(endDate);
    return Math.round(Math.abs((start.getTime() - end.getTime()) / oneDay)+1);
  }
  downloadAllLeaves() {
    
    this.leaveService.getAllLeaves().subscribe(leaves => {
      const csvData = this.leaveService.convertToCSV(leaves.data);
      const blob = new Blob([csvData], { type: 'text/csv' });
      const url = window.URL.createObjectURL(blob);
      const a = document.createElement('a');
      a.href = url;
      a.download = 'Employee_Leaves_Data.csv'; 
      document.body.appendChild(a);
      a.click();
      window.URL.revokeObjectURL(url);
      document.body.removeChild(a);
    });
  }
}
