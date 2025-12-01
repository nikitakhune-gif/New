

using System.ComponentModel.DataAnnotations;

namespace EmployeesLeaveApplication.ViewModel
{
    public class HolidayViewModel
    {
        [Key]
        public int HolidayId { get; set; }

        [Required]
        [Display(Name = "Holiday Name")]
        public string HolidayName { get; set; } = "";

        [Required]
        [Display(Name = "Holiday Date")]
        public DateTime Date { get; set; }
    }
}
