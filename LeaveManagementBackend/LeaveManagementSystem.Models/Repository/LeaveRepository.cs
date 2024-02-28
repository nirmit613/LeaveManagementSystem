using LeaveManagementSystem.Models.Interfaces;
using LeaveManagementSystem.Models.Models;
using Microsoft.EntityFrameworkCore;

namespace LeaveManagementSystem.Models.Repository
{
    public class LeaveRepository : ILeaveRepository
    {
        #region fields
        private readonly AppDbContext _context;
        #endregion
        #region Constructor
        public LeaveRepository(AppDbContext context)
        {
            _context = context;
        }

        #endregion

        #region Methods

        public IEnumerable<Leave> GetLeaves()
        {
            return _context.Leaves.Include(u => u.User).Include(l=>l.LeaveType).ToList();
        }
        public Leave GetLeaveById(int id)
        {
            return _context.Leaves.FirstOrDefault(u => u.Id == id);
        }
        public IEnumerable<Leave> GetLeaveByUserId(int userId)
        {
            return _context.Leaves.Include(u => u.User).Include(l=>l.LeaveType).Where(u => u.UserId == userId).ToList();
        }
        public int AddLeave(Leave leave)
        {
            var leaveDuration = (leave.EndDate - leave.StartDate).Days + 1;
            var leaveBalance = _context.LeaveBalances.FirstOrDefault(lb => lb.UserId == leave.UserId && lb.LeaveTypeId == leave.LeaveTypeId);

            if(leaveDuration >= leaveBalance.Balance)
            {
                throw new Exception("Leave balance is not sufficient");
            }
            else { 

            leave.DateOfRequest = DateTime.Now;
            leave.Status = "InProgress";
            _context.Leaves.Add(leave);
            if (_context.SaveChanges() > 0)
            {
                return leave.Id;
            }
            else
            {
                return 0;
            }
            }
        }
        public bool UpdateLeave(Leave leave)
        {
            var LeavesData = _context.Leaves.Find(leave.Id);
            if (LeavesData == null)
            {
                throw new InvalidOperationException("Leave not found");
            }

            var daysSinceLeaveRequest = (LeavesData.StartDate - DateTime.Today).Days;
            
            if (LeavesData.Status == "Approved" && leave.Status == "Cancelled")
            {
                int totalLeaveDays = (LeavesData.EndDate - LeavesData.StartDate).Days + 1;
                var leaveBalance = _context.LeaveBalances.FirstOrDefault(lb => lb.UserId == LeavesData.UserId && lb.LeaveTypeId == LeavesData.LeaveTypeId);

                if (leaveBalance != null)
                {
                    leaveBalance.Balance += totalLeaveDays;
                    _context.Entry(leaveBalance).State = EntityState.Modified;
                }
                else
                {
                    throw new InvalidOperationException("Leave balance not found");
                }
                LeavesData.Status = leave.Status;
                _context.Entry(LeavesData).State = EntityState.Modified;

            }
            else if (leave.Status == "Approved")
            {
                int totalLeaveDays = (LeavesData.EndDate - LeavesData.StartDate).Days + 1;
                var leaveBalance = _context.LeaveBalances.FirstOrDefault(lb => lb.UserId == LeavesData.UserId && lb.LeaveTypeId == LeavesData.LeaveTypeId);

                if (leaveBalance != null)
                {
                    if (leaveBalance.Balance >= totalLeaveDays)
                    {
                        leaveBalance.Balance -= totalLeaveDays;
                    }
                    else
                    {
                        throw new InvalidOperationException("Insufficient leave balance");
                    }
                    _context.Entry(leaveBalance).State = EntityState.Modified;
                }
                else
                {
                    throw new InvalidOperationException("Leave balance not found");
                }
                LeavesData.Status = leave.Status;
                _context.Entry(LeavesData).State = EntityState.Modified;
            }
            else if (leave.Status == "Cancelled")
            {
                if (daysSinceLeaveRequest >= 3)
                {
                    LeavesData.Status = leave.Status;
                    _context.Entry(LeavesData).State = EntityState.Modified;
                }
                else
                {
                    throw new InvalidOperationException("Leave cannot be cancelled before 3 days of request date");
                }
            }
            else
            {
                LeavesData.Status = leave.Status;
                _context.Entry(LeavesData).State = EntityState.Modified;
            }
            return _context.SaveChanges() > 0; 
        }
        #endregion
    }
}