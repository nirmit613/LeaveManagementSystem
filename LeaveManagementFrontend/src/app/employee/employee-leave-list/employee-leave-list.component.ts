import { Component } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { Router } from '@angular/router';
import { NgToastService } from 'ng-angular-popup';
import { ILeave } from 'src/app/interfaces/leave';
import { LeaveService } from 'src/app/services/leave.service';
import { AddLeaveComponent } from '../add-leave/add-leave.component';

@Component({
  selector: 'app-employee-leave-list',
  templateUrl: './employee-leave-list.component.html',
  styleUrls: ['./employee-leave-list.component.scss']
})
export class EmployeeLeaveListComponent {
  public leaveList!:ILeave[];
  userId!:number;
  constructor(private leaveService:LeaveService,private toast:NgToastService,public dialog:MatDialog) {}
  ngOnInit():void{
    this.getMyLeaves();
  }
 public getMyLeaves(): void {
    const userDataString = localStorage.getItem('UserData');
      if (userDataString) {
        const userData = JSON.parse(userDataString);
        const userId = userData.id; 
        this.userId = userId;
    this.leaveService.getLeaveByUserId(userId).subscribe({
      next: (res) => {
        console.log(res)
        this.leaveList = res.data;
        },
      error: (error) => {
        this.toast.error({detail:"Error Message",summary:"Some error occur while fetching your orders!!",duration:3000})
      },
    });
  }
  }
  cancelLeave(leave: any): void {
    leave.status = 'Cancelled'; 
    this.leaveService.UpdateLeave(leave).subscribe(
      response => {
        console.log('Leave cancelled successfully:', response);
        this.toast.success({detail:"Success Message",summary:"Your leave cancelled successfully!!",duration:3000})
        this.getMyLeaves();
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
  public AddLeave():void{
    let leaves:ILeave = {
      id:0,
      userId:0,
      leaveTypeId:0,
      startDate: new Date(),
      endDate:new Date(),
      dateOfRequest:new Date(),
      reasonForLeave:'',
      status:'',
      user:{
        firstName:''
      },
      leaveType:{
        type:'',
      }
    }
    const dialogRef = this.dialog.open(AddLeaveComponent,{
      data:leaves,
      width:'50%'
    });
    dialogRef.afterClosed().subscribe({
      next:(res)=>{
        if(res!=undefined){
          console.log(res);
          this.leaveService.AddLeave({
            id:res.id,
            userId:this.userId,
            leaveTypeId:res.leaveTypeId,
            startDate:res.startDate,
            endDate:res.endDate,
            reasonForLeave:res.reasonForLeave
          }).subscribe(
            (response)=>{
              console.log(response);
              this.toast.success({ detail: "Success Messege", summary: "Leave request added successfully!!!", duration: 3000 });
              this.getMyLeaves();
            },
            (error)=>{
              this.toast.error({ detail: "Error Message", summary:"Failed to add leave request!!" , duration: 3000 });
            }
          )
        }
      }
    })
  }
}
