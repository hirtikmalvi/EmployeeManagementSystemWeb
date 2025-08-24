using EmployeeManagementSystemWeb.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using EmployeeManagementSystemWeb.Utilities;
using EmployeeManagementSystemWeb.DTOs;
using System.Threading.Tasks;
using EmployeeManagementSystemWeb.DTOs.Employees;

namespace EmployeeManagementSystemWeb.Controllers
{
    public class EmployeeController(IEmployeeService employeeService) : Controller
    {
        public async Task<IActionResult> Index(string searchValue, string searchBy)
        {
            var result = await employeeService.GetEmployees(searchValue, searchBy);
            return View(result);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateEmployeeDTO request)
        {
            if (!ModelState.IsValid)
            {
                return View(request);
            }
            var result = await employeeService.CreateEmployee(request);
            if (result.Success)
            {
                TempData["success"] = result.Message;
            }
            else
            {
                TempData["error"] = result.Message;
            }
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Update(int id)
        {
            var result = await employeeService.GetEmployeeById(id);
            if (!result.Success)
            {
                return RedirectToAction("NotFound", "Home");
            }
            var employeeToUpdate = new UpdateEmployeeDTO
            {
                EmpID = result.Data.EmpID,
                EmpName = result.Data.EmpName,
                Salary = result.Data.Salary,
                Department = result.Data.Department,
                JoiningDate = result.Data.JoiningDate
            };
            return View(employeeToUpdate);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int id, UpdateEmployeeDTO request)
        {
            if (!ModelState.IsValid)
            {
                return View(request);
            }
            var result = await employeeService.UpdateEmployee(id, request);
            if (result.Success)
            {
                TempData["success"] = result.Message;
            }
            else
            {
                TempData["error"] = result.Message;
            }
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            var result = await employeeService.GetEmployeeById(id);
            if (!result.Success)
            {
                return RedirectToAction("NotFound", "Home");
            }
            var employeeToDelete = new DisplayEmployeeDTO
            {
                EmpID = result.Data.EmpID,
                EmpName = result.Data.EmpName,
                Salary = result.Data.Salary,
                Department = result.Data.Department,
                JoiningDate = result.Data.JoiningDate
            };
            return View(employeeToDelete);
        }

        [HttpPost,ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeletePOST(int id)
        {
            var result = await employeeService.DeleteEmployee(id);
            if (result.Success)
            {
                TempData["success"] = result.Message;
            }
            else
            {
                TempData["error"] = result.Message;
            }
            return RedirectToAction("Index");
        }
    }
}
