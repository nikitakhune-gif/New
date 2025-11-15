using System.ComponentModel.DataAnnotations;

namespace EmployeesLeaveApplication.Models
{
    public class LeaveType
    {
        [Key]
        public int LeaveTypeId { get; set; }

        [Required]
        public string TypeName { get; set; } = "";

        public int DefaultDays { get; set; }
    }
}
