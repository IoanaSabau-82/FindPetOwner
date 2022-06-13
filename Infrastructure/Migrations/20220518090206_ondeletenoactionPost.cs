using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class ondeletenoactionPost : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AssignedVolunteers_FoundPetPosts_PostId",
                table: "AssignedVolunteers");

            migrationBuilder.AddForeignKey(
                name: "FK_AssignedVolunteers_FoundPetPosts_PostId",
                table: "AssignedVolunteers",
                column: "PostId",
                principalTable: "FoundPetPosts",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AssignedVolunteers_FoundPetPosts_PostId",
                table: "AssignedVolunteers");

            migrationBuilder.AddForeignKey(
                name: "FK_AssignedVolunteers_FoundPetPosts_PostId",
                table: "AssignedVolunteers",
                column: "PostId",
                principalTable: "FoundPetPosts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
