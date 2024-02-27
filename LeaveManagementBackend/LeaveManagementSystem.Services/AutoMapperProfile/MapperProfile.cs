using AutoMapper;
using LeaveManagementSystem.Models.Models;
using LeaveManagementSystem.Services.DTO;

namespace LeaveManagementSystem.Services.AutoMapperProfile
{
    public class MapperProfile:Profile
    {
        public MapperProfile()
        {
            #region User
            CreateMap<AuthenticationDTO, User>();
            CreateMap<AddUserDTO, User>();
            #endregion

            #region Leave
            CreateMap<AddLeaveDTO,Leave>();
            CreateMap<UpdateLeaveDTO,Leave>();
            #endregion

        }
    }
}
