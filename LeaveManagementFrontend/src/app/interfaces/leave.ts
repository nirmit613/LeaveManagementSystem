export interface ILeave {
    id:number,
    userId:number,
    leaveTypeId:number,
    startDate:Date,
    endDate:Date,
    dateOfRequest:Date,
    reasonForLeave:string,
    status:string,
    user:{
        firstName:string
    },
    leaveType:{
        type:string
    }
}
