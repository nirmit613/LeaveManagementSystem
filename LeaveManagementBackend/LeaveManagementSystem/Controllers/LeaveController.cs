using LeaveManagementSystem.Models.Models;
using LeaveManagementSystem.Services.DTO;
using LeaveManagementSystem.Services.Interfaces;
using LeaveManagementSystem.Services.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Text;

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
        [HttpGet("CSV")]
        public IActionResult DownloadAllLeaves()
        {
            var response = _leaveService.GetLeaves();
            if (response.Status == 200 && response.Data != null) 
            {
                var leaves = response.Data as List<Leave>; 
                var csvData = ToCsv(leaves);

                var fileName = "Employee_Leaves_Data.csv";
                var contentType = "text/csv";
                return File(new System.Text.UTF8Encoding().GetBytes(csvData), contentType,fileName);
            }
            else
            {
                return StatusCode(response.Status, response.Message);
            }
        }

        private string ToCsv(IEnumerable<Leave> leaves)
        {
            var sb = new StringBuilder();
            sb.AppendLine("EmployeeName , StartDate,EndDate,Reason,DateOfRequest");

            foreach (var item in leaves)
            {
                var employeeName = $"{item.User.FirstName }";
                var startDate = item.StartDate.ToString("yyyy-MM-dd");
                var endDate = item.EndDate.ToString("yyyy-MM-dd");
                sb.AppendLine($"{employeeName},{startDate},{endDate},{item.ReasonForLeave},{item.DateOfRequest}");

            }
            return sb.ToString();
        }

        #endregion


    }
}
