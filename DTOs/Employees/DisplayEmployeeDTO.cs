namespace EmployeeManagementSystemWeb.DTOs.Employees
{
    public class DisplayEmployeeDTO
    {
        public int EmpID { get; set; }
        public string EmpName { get; set; }
        public string Department { get; set; }
        public decimal Salary { get; set; }
        public DateTime JoiningDate { get; set; }
    }
}
