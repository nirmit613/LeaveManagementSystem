using LeaveManagementSystem.Models.Models;
using LeaveManagementSystem.Services.DTO;

namespace LeaveManagementSystem.Services.Interfaces
{
    public interface IUserService
    {
        ResponseDTO GetUsers();
        ResponseDTO GetUserbyId(int id);
        ResponseDTO GetUserbyEmail(string email);
        ResponseDTO AddUser(AddUserDTO user);
        User IsUserExist(AuthenticationDTO user);
    }
}
