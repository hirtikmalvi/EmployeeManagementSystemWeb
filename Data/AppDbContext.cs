using EmployeeManagementSystemWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagementSystemWeb.Data
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().HasData(
                new Employee
                {
                    EmpID = 1,
                    EmpName = "Hirtik Malvi",
                    Department = "Engineering",
                    Salary = 32000,
                    JoiningDate = new DateTime(2025, 7, 31)
                },
                new Employee
                {
                    EmpID = 2,
                    EmpName = "Hitesh Joshi",
                    Department = "HR",
                    Salary = 25000,
                    JoiningDate = new DateTime(2025, 7, 15)
                },
                new Employee
                {
                    EmpID = 3,
                    EmpName = "Rutul Patel",
                    Department = "Finance",
                    Salary = 35000,
                    JoiningDate = new DateTime(2025, 8, 15)
                },
                new Employee
                {
                    EmpID = 4,
                    EmpName = "Jay Patel",
                    Department = "Sales",
                    Salary = 30000,
                    JoiningDate = new DateTime(2025, 8, 1)
                },
                new Employee
                {
                    EmpID = 5,
                    EmpName = "Chintan Patil",
                    Department = "Marketing",
                    Salary = 22000,
                    JoiningDate = new DateTime(2025, 6, 1)
                }
            );
        }

        public DbSet<Employee> Employees { get; set; }
    }
}
