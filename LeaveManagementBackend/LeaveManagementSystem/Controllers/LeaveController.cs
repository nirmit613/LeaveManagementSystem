using LeaveManagementSystem.Services.DTO;
using LeaveManagementSystem.Services.Interfaces;
using LeaveManagementSystem.Services.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LeaveManagementSystem.Controllers
{
    [Route("api/leaves")]
    [ApiController]
    public class LeaveController : ControllerBase
    {
        #region Fields
        private readonly ILeaveService _leaveService;
        #endregion
        #region Constructor
        public LeaveController(ILeaveService leaveService)
        {
            _leaveService = leaveService;
        }
        #endregion

        #region Methods
        [HttpGet("Leaves")]
        public IActionResult GetLeaves()
        {
            return Ok(_leaveService.GetLeaves());
        }
        [HttpGet("id")]
        public IActionResult GetLeaveById(int id)
        {
            return Ok(_leaveService.GetLeaveById(id));
        }
        [HttpGet("userId")]
        public IActionResult GetLeaveByUserId(int userId)
        {
            return Ok(_leaveService.GetLeaveByUserId(userId));
        }
        [HttpPost("leave")]
        [AllowAnonymous]
        public IActionResult Addleave(AddLeaveDTO leave)
        {
            return Ok(_leaveService.AddLeave(leave));
        }
        [HttpPut]
        public IActionResult UpdateLeave(UpdateLeaveDTO leave)
        {
            return Ok(_leaveService.UpdateLeave(leave));
        }
        #endregion


    }
}
