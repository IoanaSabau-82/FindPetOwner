using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class latLongFieldsOnPosts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Longitude",
                table: "FoundPetPosts",
                newName: "Lng");

            migrationBuilder.RenameColumn(
                name: "Latitude",
                table: "FoundPetPosts",
                newName: "Lat");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Lng",
                table: "FoundPetPosts",
                newName: "Longitude");

            migrationBuilder.RenameColumn(
                name: "Lat",
                table: "FoundPetPosts",
                newName: "Latitude");
        }
    }
}
