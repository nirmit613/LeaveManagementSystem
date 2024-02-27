using System.ComponentModel.DataAnnotations;

namespace LeaveManagementSystem.Models.Models
{
    public class LeaveType
    {
        [Key] 
        public int Id { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public DateTime ValidityFrom { get; set; }
        public DateTime ValidityTo { get; set; }
    }
}
