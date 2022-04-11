using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class columnNameUpdates : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "Users",
                newName: "Last name");

            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "Users",
                newName: "First name");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Last name",
                table: "Users",
                newName: "LastName");

            migrationBuilder.RenameColumn(
                name: "First name",
                table: "Users",
                newName: "FirstName");
        }
    }
}
