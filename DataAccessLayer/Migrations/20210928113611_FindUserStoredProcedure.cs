using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class FindUserStoredProcedure : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var storedProcedure = @"CREATE PROCEDURE [dbo].[FinUser]
                            @NameToSearch varchar(50)
                            AS
                            BEGIN
                            SET NOCOUNT ON;
                            select *from Users where FirstName = @NameToSearch
                            END";
            migrationBuilder.Sql(storedProcedure);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
