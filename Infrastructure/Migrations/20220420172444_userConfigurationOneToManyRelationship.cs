using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class userConfigurationOneToManyRelationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FoundPetPosts_Users_MadeById",
                table: "FoundPetPosts");

            migrationBuilder.RenameColumn(
                name: "MadeById",
                table: "FoundPetPosts",
                newName: "CreatedById");

            migrationBuilder.RenameIndex(
                name: "IX_FoundPetPosts_MadeById",
                table: "FoundPetPosts",
                newName: "IX_FoundPetPosts_CreatedById");

            migrationBuilder.AddForeignKey(
                name: "FK_FoundPetPosts_Users_CreatedById",
                table: "FoundPetPosts",
                column: "CreatedById",
                principalTable: "Users",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FoundPetPosts_Users_CreatedById",
                table: "FoundPetPosts");

            migrationBuilder.RenameColumn(
                name: "CreatedById",
                table: "FoundPetPosts",
                newName: "MadeById");

            migrationBuilder.RenameIndex(
                name: "IX_FoundPetPosts_CreatedById",
                table: "FoundPetPosts",
                newName: "IX_FoundPetPosts_MadeById");

            migrationBuilder.AddForeignKey(
                name: "FK_FoundPetPosts_Users_MadeById",
                table: "FoundPetPosts",
                column: "MadeById",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
