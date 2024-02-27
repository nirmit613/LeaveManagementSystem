using LeaveManagementSystem.Models.Models;

namespace LeaveManagementSystem.Models.Interfaces
{
    public interface ILeaveRepository
    {
        IEnumerable<Leave> GetLeaves();
        Leave GetLeaveById(int id);
        IEnumerable<Leave> GetLeaveByUserId(int userId);
        int AddLeave(Leave leave);
        bool UpdateLeave(Leave leave);
        //bool CancelLeave(Leave leave);
      
    }
}
