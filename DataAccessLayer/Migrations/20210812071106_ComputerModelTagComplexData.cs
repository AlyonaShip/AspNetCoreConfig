using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class ComputerModelTagComplexData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SalesInfo_DepartmentLocation",
                table: "ComputerModelTags",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SalesInfo_DepartmentZipCode",
                table: "ComputerModelTags",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SalesInfo_SalesDepartment",
                table: "ComputerModelTags",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SalesInfo_DepartmentLocation",
                table: "ComputerModelTags");

            migrationBuilder.DropColumn(
                name: "SalesInfo_DepartmentZipCode",
                table: "ComputerModelTags");

            migrationBuilder.DropColumn(
                name: "SalesInfo_SalesDepartment",
                table: "ComputerModelTags");
        }
    }
}
