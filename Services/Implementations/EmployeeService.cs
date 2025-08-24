using EmployeeManagementSystemWeb.Data;
using EmployeeManagementSystemWeb.DTOs.Employees;
using EmployeeManagementSystemWeb.Models;
using EmployeeManagementSystemWeb.Services.Interfaces;
using EmployeeManagementSystemWeb.Utilities;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace EmployeeManagementSystemWeb.Services.Implementations
{
    public class EmployeeService : IEmployeeService
    {
        private readonly AppDbContext context;
        public EmployeeService(AppDbContext _context)
        {
            context = _context;
        }

        // CREATE
        public async Task<CustomResult<string>> CreateEmployee(CreateEmployeeDTO request)
        {
            var employeeToAdd = new Employee
            {
                EmpName = request.EmpName,
                Department = request.Department,
                Salary = request.Salary,
                JoiningDate = request.JoiningDate
            };
            var emp = await context.Employees.AddAsync(employeeToAdd);
            await context.SaveChangesAsync();
            return CustomResult<string>.Ok("Employee Added", $"Employee added successfully and EmpID is {emp.Entity.EmpID}");
        }

        // DELETE
        public async Task<CustomResult<string>> DeleteEmployee(int id)
        {
            var employee = await context.Employees.FirstOrDefaultAsync(e => e.EmpID == id);

            if(employee == null)
            {
                return CustomResult<string>.Fail($"Employee with EmpID: {id} does not exists.");
            }
            context.Employees.Remove(employee);
            await context.SaveChangesAsync();
            return CustomResult<string>.Ok("Employee Deleted", $"Employee with EmpID:{id} deleted successfully.");
        }

        // READ BY ID
        public async Task<CustomResult<DisplayEmployeeDTO>> GetEmployeeById(int id)
        {
            if (id <= 0)
            {
                return CustomResult<DisplayEmployeeDTO>.Fail($"EmpID: {id} is invalid.");
            }
            var employee = await context.Employees.Where(e => e.EmpID == id).Select(e => new DisplayEmployeeDTO
            {
                EmpID = e.EmpID,
                EmpName = e.EmpName,
                Salary = e.Salary,
                Department = e.Department,
                JoiningDate = e.JoiningDate
            }).FirstOrDefaultAsync();

            if (employee == null)
            {
                return CustomResult<DisplayEmployeeDTO>.Fail($"Employee with EmpID:{id} not found.");
            }
            return CustomResult<DisplayEmployeeDTO>.Ok(employee, $"Employee found successfully.");
        }

        // READ ALL
        public async Task<CustomResult<List<DisplayEmployeeDTO>>> GetEmployees(string searchValue, string searchBy)
        {
            var employees = context.Employees.Select(e => new DisplayEmployeeDTO
            {
                EmpID = e.EmpID,
                EmpName = e.EmpName,
                Salary = e.Salary,
                Department = e.Department,
                JoiningDate = e.JoiningDate
            });

            if (!string.IsNullOrEmpty(searchValue) && !string.IsNullOrEmpty(searchBy))
            {
                searchBy = searchBy.Trim().ToLower();
                searchValue = searchValue.Trim().ToLower();

                if (searchBy == "department")
                {
                    employees = employees.Where(e => e.Department.Trim().ToLower().Contains(searchValue));
                }
                else if (searchBy == "empname")
                {
                    employees = employees.Where(e => e.EmpName.Trim
                      ().Contains(searchValue));
                }
            }
            var employeeList = await employees.ToListAsync();
            if (employeeList == null || employeeList.Count == 0)
            {
                return CustomResult<List<DisplayEmployeeDTO>>.Fail($"Employees not found.");
            }
            return CustomResult<List<DisplayEmployeeDTO>>.Ok(employeeList, $"Employees fetched successfully.");
        }

        // UPDATE
        public async Task<CustomResult<string>> UpdateEmployee(int id, UpdateEmployeeDTO request)
        {
            if (id <= 0 || (id != request.EmpID))
            {
                return CustomResult<string>.Fail($"EmpID: {id} is invalid.");
            }

            var employee = await context.Employees.FirstOrDefaultAsync(e => e.EmpID == id);

            if (employee == null)
            {
                return CustomResult<string>.Fail($"Employee with EmpID: {id} does not exists.");
            }
            employee.Salary = request.Salary;
            employee.Department = request.Department;

            context.Employees.Update(employee);
            await context.SaveChangesAsync();
           
            return CustomResult<string>.Ok("Employee Updated", $"Employee with EmpID:{id} updated successfully.");
        }
    }
}
