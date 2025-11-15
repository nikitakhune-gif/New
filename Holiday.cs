using System.ComponentModel.DataAnnotations;

namespace EmployeesLeaveApplication.Models
{
    public class Holiday
    {
        [Key]
        public int HolidayId { get; set; }

        [Required]
        public string HolidayName { get; set; } = "";

        [Required]
        public DateTime Date { get; set; }
    }
}
