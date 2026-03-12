using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TimeTracking.Infrastructure.Migrations
{
    public partial class SeedDataAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "EmployeeCode", "FullName", "IsActive" },
                values: new object[,]
                {
                    { 1, "EMP001", "Haseeb Naqvi", true },
                    { 2, "EMP002", "Osama Asghar", true }
                });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "IsActive", "Name", "ProjectCode" },
                values: new object[,]
                {
                    { 1, true, "Internal Tools", "PRJ001" },
                    { 2, true, "Customer Portal", "PRJ002" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
