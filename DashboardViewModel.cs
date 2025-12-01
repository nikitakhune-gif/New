using System.ComponentModel.DataAnnotations;

namespace EmployeesLeaveApplication.ViewModel
{
    public class DashboardViewModel
    {
        [Key]
        public int TotalEmployees { get; set; }
        public int TotalLeaveRequests { get; set; }
    }
}
