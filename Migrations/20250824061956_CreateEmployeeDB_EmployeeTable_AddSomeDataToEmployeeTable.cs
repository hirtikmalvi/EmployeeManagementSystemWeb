using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EmployeeManagementSystemWeb.Migrations
{
    /// <inheritdoc />
    public partial class CreateEmployeeDB_EmployeeTable_AddSomeDataToEmployeeTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmpID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmpName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Department = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Salary = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    JoiningDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmpID);
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmpID", "Department", "EmpName", "JoiningDate", "Salary" },
                values: new object[,]
                {
                    { 1, "Engineering", "Hirtik Malvi", new DateTime(2025, 7, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 32000m },
                    { 2, "HR", "Hitesh Joshi", new DateTime(2025, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 25000m },
                    { 3, "Finance", "Rutul Patel", new DateTime(2025, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 35000m },
                    { 4, "Sales", "Jay Patel", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 30000m },
                    { 5, "Marketing", "Chintan Patil", new DateTime(2025, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 22000m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");
        }
    }
}
