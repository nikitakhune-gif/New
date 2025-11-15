using System.ComponentModel.DataAnnotations;

namespace EmployeesLeaveApplication.Models
{
    public class LeaveApplication
    {
        [Key]
        public int LeaveID { get; set; }

        [Required]
        public int EmployeeId { get; set; }

        [Required]
        public int LeaveTypeId { get; set; }

        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }

        public string Reason { get; set; } = "";

        public int StatusId { get; set; }
    }
}
