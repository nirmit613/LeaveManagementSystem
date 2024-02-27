using System.ComponentModel.DataAnnotations;

namespace LeaveManagementSystem.Services.DTO
{
    public class AddUserDTO
    {
        [Required(ErrorMessage = "First name is required")]
        [MaxLength(30, ErrorMessage = "First name cannot be longer than 30 characters")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required")]
        [MaxLength(30, ErrorMessage = "Last name cannot be longer than 30 characters")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Email address is invalid")]
        [MaxLength(64, ErrorMessage = "Email address cannot be longer than 64 characters")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [MaxLength(256)]
        public string Password { get; set; }

        [RegularExpression(@"^\d{10}$", ErrorMessage = "Mobile number must contain 10 digits only")]
        [MaxLength(10)]
        public string MobileNumber { get; set; }

        [Required(ErrorMessage = "Department is required")]
        [MaxLength(30, ErrorMessage = "Department cannot be longer than 30 characters")]
        public string Department { get; set; }

        [Required(ErrorMessage = "Designation is required")]
        [MaxLength(30, ErrorMessage = "Designation cannot be longer than 30 characters")]
        public string Designation { get; set; }

        [Required(ErrorMessage = "Role ID is required")]
        public int RoleId { get; set; }
    }
}
