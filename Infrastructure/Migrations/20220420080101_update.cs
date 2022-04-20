using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pictures_FoundPetPosts_PostId",
                table: "Pictures");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Pictures",
                table: "Pictures");

            migrationBuilder.RenameTable(
                name: "Pictures",
                newName: "Picture");

            migrationBuilder.RenameIndex(
                name: "IX_Pictures_PostId",
                table: "Picture",
                newName: "IX_Picture_PostId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Picture",
                table: "Picture",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Picture_FoundPetPosts_PostId",
                table: "Picture",
                column: "PostId",
                principalTable: "FoundPetPosts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Picture_FoundPetPosts_PostId",
                table: "Picture");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Picture",
                table: "Picture");

            migrationBuilder.RenameTable(
                name: "Picture",
                newName: "Pictures");

            migrationBuilder.RenameIndex(
                name: "IX_Picture_PostId",
                table: "Pictures",
                newName: "IX_Pictures_PostId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Pictures",
                table: "Pictures",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Pictures_FoundPetPosts_PostId",
                table: "Pictures",
                column: "PostId",
                principalTable: "FoundPetPosts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
