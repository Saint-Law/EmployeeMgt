using Microsoft.EntityFrameworkCore.Migrations;

namespace EmployeeMgt.Data.Migrations
{
    public partial class fixEmployeeClass : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GuarantorAddress1",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "GuarantorAddress2",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "GuarantorName1",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "GuarantorName2",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "GuarantorPhone1",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "GuarantorPhone2",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "KinAddress",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "KinMobile",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "KinName",
                table: "Employees");

            migrationBuilder.AddColumn<string>(
                name: "Department",
                table: "Employees",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Department",
                table: "Employees");

            migrationBuilder.AddColumn<string>(
                name: "GuarantorAddress1",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GuarantorAddress2",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GuarantorName1",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GuarantorName2",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GuarantorPhone1",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GuarantorPhone2",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "KinAddress",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "KinMobile",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "KinName",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
