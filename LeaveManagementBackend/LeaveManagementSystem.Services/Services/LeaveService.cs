using AutoMapper;
using LeaveManagementSystem.Models.Interfaces;
using LeaveManagementSystem.Models.Models;
using LeaveManagementSystem.Models.Repository;
using LeaveManagementSystem.Services.DTO;
using LeaveManagementSystem.Services.Interfaces;

namespace LeaveManagementSystem.Services.Services
{
    public class LeaveService : ILeaveService
    {
        #region Fields
        private readonly IMapper _mapper;
        private readonly ILeaveRepository _leaveRepository;
        #endregion

        #region Constructors
        public LeaveService(IMapper mapper, ILeaveRepository leaveRepository)
        {
            _mapper = mapper;
            _leaveRepository = leaveRepository;
        }

        #endregion

        #region Methods
        public ResponseDTO GetLeaves()
        {
            var response = new ResponseDTO();
            try
            {
                var data = _mapper.Map<List<Leave>>(_leaveRepository.GetLeaves().ToList());
                response.Status = 200;
                response.Message = "Ok";
                response.Data = data;
            }
            catch (Exception e)
            {
                response.Status = 500;
                response.Message = "Internal Server Error";
                response.Error = e.Message;
            }
            return response;
        }
        public ResponseDTO GetLeaveById(int id)
        {
            var response = new ResponseDTO();
            try
            {
                var leave = _leaveRepository.GetLeaveById(id);
                if (leave == null)
                {
                    response.Status = 404;
                    response.Message = "Not Found";
                    response.Error = "Leave not found";
                    return response;
                }
                var result = _mapper.Map<Leave>(leave);

                response.Status = 200;
                response.Message = "Ok";
                response.Data = result;
            }
            catch (Exception e)
            {
                response.Status = 500;
                response.Message = "Internal Server Error";
                response.Error = e.Message;
            }
            return response;
        }
        public ResponseDTO GetLeaveByUserId(int userId)
        {
            var response = new ResponseDTO();
            try
            {
                var leaves = _leaveRepository.GetLeaveByUserId(userId);

                if (leaves == null || !leaves.Any())
                {
                    response.Status = 404;
                    response.Message = "Not Found";
                    response.Error = "Leaves not found for the specified User Id";
                    return response;
                }
                var leavesData = _mapper.Map<List<Leave>>(leaves);

                response.Status = 200;
                response.Message = "Ok";
                response.Data = leavesData;
            }
            catch (Exception e)
            {
                response.Status = 500;
                response.Message = "Internal Server Error";
                response.Error = e.Message;
            }
            return response;
        }

        public ResponseDTO AddLeave(AddLeaveDTO leave)
        {
            var response = new ResponseDTO();
            try
            {
                if(leave.StartDate.Date < DateTime.Now)
                {
                    response.Status = 400;
                    response.Message = "Bad Request";
                    response.Error = "Leave start Date can not be a past date.";
                    return response;
                }
                if(leave.EndDate.Date < leave.StartDate.Date)
                {
                    response.Status = 400;
                    response.Message = "Invalid dates added";
                    response.Error = "Invalid dates added";
                    return response;
                }
                var result = _leaveRepository.AddLeave(_mapper.Map<Leave>(leave));
                if (result == 0)
                {
                    response.Status = 400;
                    response.Message = "Leave is not added";
                    response.Error = "Leave is not added";
                    return response;
                }
                response.Status = 201;
                response.Message = "Leave added successfully";
                response.Data = result;
            }
            catch(Exception e)
            {
                response.Status = 500;
                response.Message = "Internal Server Error";
                response.Error = e.Message;
            }
            return response;
        }
        public ResponseDTO UpdateLeave(UpdateLeaveDTO leave)
        {
            var response = new ResponseDTO();
            try
            {
                var leaveData = _leaveRepository.GetLeaveById(leave.Id);
                if(leaveData == null)
                {
                    response.Status = 404;
                    response.Message = "Leave not found";
                    return response;
                }
                var updateLeave = _leaveRepository.UpdateLeave(_mapper.Map<Leave>(leave));
                if (updateLeave)
                {
                    response.Status = 204;
                    response.Message = "Leave status updated successfully";
                }
                else
                {
                    response.Status = 400;
                    response.Message = "Not Updated";
                    response.Error = "Could not update leave status"; ;
                }
            }
            catch(Exception e)
            {
                response.Status = 500;
                response.Message = "Internal Server Error";
                response.Error = e.Message;
            }
            return response;
        }
        #endregion
    }
}
