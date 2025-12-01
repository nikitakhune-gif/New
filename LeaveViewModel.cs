

using System.ComponentModel.DataAnnotations;

namespace EmployeesLeaveApplication.ViewModel
{
    public class LeaveViewModels
    {
        [Key]
        public int LeaveID { get; set; }

        [Required]
        [Display(Name = "Employee")]
        public int EmployeeId { get; set; }

        [Required]
        [Display(Name = "Leave Type")]
        public int LeaveTypeId { get; set; }

        [Required]
        [Display(Name = "From Date")]
        public DateTime FromDate { get; set; }

        [Required]
        [Display(Name = "To Date")]
        public DateTime ToDate { get; set; }

        [Display(Name = "Reason")]
        public string Reason { get; set; } = "";

        [Display(Name = "Status")]
        public int StatusId { get; set; }

        // Optional Display Fields
        public string EmployeeName { get; set; } = "";
        public string LeaveTypeName { get; set; } = "";
        public string StatusName { get; set; } = "";
    }
}