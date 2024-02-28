import { Component, Inject } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA, MatDialog } from '@angular/material/dialog';
import { ILeave } from 'src/app/interfaces/leave';

@Component({
  selector: 'app-add-leave',
  templateUrl: './add-leave.component.html',
  styleUrls: ['./add-leave.component.scss']
})
export class AddLeaveComponent {
public AddLeaveForm!:FormGroup
constructor(
  public dialogRef: MatDialogRef<AddLeaveComponent>,
  @Inject(MAT_DIALOG_DATA) public data: ILeave,public dialog: MatDialog
) {}
ngOnInit(): void {
  this.initializeForm();
}
public initializeForm(): void {
  this.AddLeaveForm = new FormGroup({
    id: new FormControl(this.data.id ?? null),
    leaveTypeId: new FormControl(this.data.leaveTypeId, Validators.required),
    startDate: new FormControl(this.data.startDate, Validators.required),
    endDate: new FormControl(this.data.endDate, Validators.required),
    reasonForLeave: new FormControl(this.data.reasonForLeave, Validators.required),
  });
}
public AddLeave(){
  console.log(this.AddLeaveForm.value);
  this.dialogRef.close(this.AddLeaveForm.value);
  
}
public close() {
  this.dialogRef.close();
}
public minDate():string{
  return new Date().toISOString().split('T')[0];
}

}
