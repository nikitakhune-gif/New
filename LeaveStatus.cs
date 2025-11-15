using System.ComponentModel.DataAnnotations;

namespace EmployeesLeaveApplication.Models
{
    public class LeaveStatus
    {
        [Key]
        public int StatusID { get; set; }

        [Required]
        public string StatusName { get; set; } = "";
    }
}
