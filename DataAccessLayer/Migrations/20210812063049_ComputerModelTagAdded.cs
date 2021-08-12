using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class ComputerModelTagAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ComputerManufacturers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ManufacturerName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComputerManufacturers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ComputerModels",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ModelName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ComputerManufacturerId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComputerModels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ComputerModelTags",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TagName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TagMeta = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TagExpiration = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ComputerModelId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComputerModelTags", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ComputerModelTags_ComputerModels_ComputerModelId",
                        column: x => x.ComputerModelId,
                        principalTable: "ComputerModels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ComputerModelTags_ComputerModelId",
                table: "ComputerModelTags",
                column: "ComputerModelId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ComputerManufacturers");

            migrationBuilder.DropTable(
                name: "ComputerModelTags");

            migrationBuilder.DropTable(
                name: "ComputerModels");
        }
    }
}
