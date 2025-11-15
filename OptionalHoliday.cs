using System.ComponentModel.DataAnnotations;

namespace EmployeesLeaveApplication.Models
{
    public class OptionalHoliday
    {
        [Key]
        public int OptionalHolidayId { get; set; }

        public string HolidayName { get; set; } = "";

        public DateTime Date { get; set; }

        public bool IsSelected { get; set; } = false;
    }
}
