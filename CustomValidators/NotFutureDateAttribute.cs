using System.ComponentModel.DataAnnotations;

namespace EmployeeManagementSystemWeb.CustomValidators
{
    public class NotFutureDateAttribute: ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            var inputDate = (DateTime?)value;
            if (inputDate != null)
            {
                return inputDate <= DateTime.Today;
            }
            return true;
        }
    }
}
