using EmployeeManagementSystemWeb.DTOs.Employees;
using EmployeeManagementSystemWeb.Utilities;

namespace EmployeeManagementSystemWeb.Services.Interfaces
{
    public interface IEmployeeService
    {
        // CREATE
        Task<CustomResult<string>> CreateEmployee(CreateEmployeeDTO request);

        // READ ALL
        Task<CustomResult<List<DisplayEmployeeDTO>>> GetEmployees(string searchValue, string searchBy);

        // READ BY ID
        Task<CustomResult<DisplayEmployeeDTO>> GetEmployeeById(int id);

        // UPDATE
        Task<CustomResult<string>> UpdateEmployee(int id, UpdateEmployeeDTO request);

        // DELETE
        Task<CustomResult<string>> DeleteEmployee(int id);
    }
}
