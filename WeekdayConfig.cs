using System.ComponentModel.DataAnnotations;

namespace EmployeesLeaveApplication.Models
{
    public class WeekdayConfig
    {
        [Key]
        public int ConfigID { get; set; }
        public string DayName { get; set; }
        public bool IsWorkingDay { get; set; }
        public bool IsHalfDay { get; set; }
    }
}
