using System.ComponentModel.DataAnnotations;

namespace EmployeesLeaveApplication.Models
{
    public class LeaveBalance
    {
        [Key]
        public int BalanceID { get; set; }

        public int EmployeeId { get; set; }
        public int LeaveTypeId { get; set; }

        public int TotalLeaves { get; set; }
        public int LeavesTaken { get; set; }
        public int RemainingLeaves { get; set; }
    }
}
