using System.ComponentModel.DataAnnotations;

namespace LeaveManagementSystem.Models.Models
{
    public class Role
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(20)]
        public string RoleName { get; set; }
    }
}
