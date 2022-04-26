using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class AssignedVolunteersConfigurationManyToOneRelationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AssignedVolunteers_FoundPetPosts_PostId",
                table: "AssignedVolunteers");

            migrationBuilder.DropForeignKey(
                name: "FK_AssignedVolunteers_Users_AssignedToId",
                table: "AssignedVolunteers");

            migrationBuilder.AddColumn<Guid>(
                name: "AssignmentId",
                table: "FoundPetPosts",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddForeignKey(
                name: "FK_AssignedVolunteers_FoundPetPosts_PostId",
                table: "AssignedVolunteers",
                column: "PostId",
                principalTable: "FoundPetPosts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AssignedVolunteers_Users_AssignedToId",
                table: "AssignedVolunteers",
                column: "AssignedToId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AssignedVolunteers_FoundPetPosts_PostId",
                table: "AssignedVolunteers");

            migrationBuilder.DropForeignKey(
                name: "FK_AssignedVolunteers_Users_AssignedToId",
                table: "AssignedVolunteers");

            migrationBuilder.DropColumn(
                name: "AssignmentId",
                table: "FoundPetPosts");

            migrationBuilder.AddForeignKey(
                name: "FK_AssignedVolunteers_FoundPetPosts_PostId",
                table: "AssignedVolunteers",
                column: "PostId",
                principalTable: "FoundPetPosts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AssignedVolunteers_Users_AssignedToId",
                table: "AssignedVolunteers",
                column: "AssignedToId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
