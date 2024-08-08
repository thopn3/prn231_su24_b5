using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyCodeFirstHR.Migrations
{
    public partial class AddDatatoEmployees : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeId", "DateOfBirth", "Email", "FirstName", "Gender", "LastName", "PhoneNumber" },
                values: new object[] { 1L, new DateTime(2009, 10, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "thopn3@fpt.edu.vn", "Tho", true, "Pham Ngoc", "099999999" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeId", "DateOfBirth", "Email", "FirstName", "Gender", "LastName", "PhoneNumber" },
                values: new object[] { 2L, new DateTime(2005, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "huongtt@fpt.edu.vn", "Huong", false, "Tran Thu", "098888888" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 2L);
        }
    }
}
