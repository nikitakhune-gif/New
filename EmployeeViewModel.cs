using System.ComponentModel.DataAnnotations;

namespace EmployeesLeaveApplication.ViewModel
{
    
        public class EmployeeViewModel
        {
        [Key]
            public int EmployeeID { get; set; }

            public string FullName { get; set; } = "";

            public string Department { get; set; } = "";

            public string Designation { get; set; } = "";

            public string Email { get; set; } = "";

            public string Phone { get; set; } = "";

            public DateTime HireDate { get; set; }

            public string Status { get; set; } = "";
        }
    }

