using LeaveManagementSystem.Services.DTO;

namespace LeaveManagementSystem.Services.Interfaces
{
    public interface ILeaveService
    {
        ResponseDTO GetLeaves();
        ResponseDTO GetLeaveById(int id);
        ResponseDTO GetLeaveByUserId(int userId);
        ResponseDTO AddLeave(AddLeaveDTO leave);
        ResponseDTO UpdateLeave(UpdateLeaveDTO leave);
    }
}
