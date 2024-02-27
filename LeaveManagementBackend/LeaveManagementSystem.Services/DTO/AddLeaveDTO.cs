namespace LeaveManagementSystem.Services.DTO
{
    public class AddLeaveDTO
    {
        public int UserId { get; set; }
        public int LeaveTypeId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string ReasonForLeave { get; set; }
    }
}
