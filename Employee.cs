using System.ComponentModel.DataAnnotations;

namespace EmployeesLeaveApplication.Models
{
    public class Employee
    {

        [Key]
        public int EmployeeID { get; set; }

        [Required]
        public string FirstName { get; set; } = "";

        [Required]
        public string LastName { get; set; } = "";

        public string Department { get; set; } = "";
        public string Designation { get; set; } = "";

        [Required]
        public string Email { get; set; } = "";

        public string Phone { get; set; } = "";

        public DateTime HireDate { get; set; } = DateTime.Now;

        public string Status { get; set; } = "Active";
    }
}
