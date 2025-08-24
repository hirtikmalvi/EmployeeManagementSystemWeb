using EmployeeManagementSystemWeb.CustomValidators;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EmployeeManagementSystemWeb.DTOs.Employees
{
    public class CreateEmployeeDTO
    {
        [DisplayName("Employee Name")]
        [Required(ErrorMessage = "Name cannot be empty.")]
        public string EmpName { get; set; }

        [Required(ErrorMessage = "Department is required.")]
        public string Department { get; set; }

        [Required(ErrorMessage = "Salary is required.")]
        [Range(1, double.MaxValue, ErrorMessage = "Salary must be > 0")]
        public decimal Salary { get; set; }

        [DisplayName("Joining Date")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = $"Joining Date is required.")]
        [NotFutureDate(ErrorMessage = "Joining Date cannot be in future.")]
        public DateTime JoiningDate { get; set; }
    }
}
