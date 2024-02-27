using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LeaveManagementSystem.Models.Models
{
    public class LeaveBalance
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("User")]
        public int UserId {  get; set; }
        public User User { get; set; }

        [ForeignKey("LeaveType")]
        public int LeaveTypeId {  get; set; }
        public LeaveType LeaveType { get; set; }
        public int Balance { get; set; }


    }
}
