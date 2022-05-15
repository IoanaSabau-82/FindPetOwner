using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class changedFieldNames : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AvailabilityEnd",
                table: "FoundPetPosts");

            migrationBuilder.DropColumn(
                name: "AvailabilityStart",
                table: "FoundPetPosts");

            migrationBuilder.RenameColumn(
                name: "Comment",
                table: "FoundPetPosts",
                newName: "Details");

            migrationBuilder.AddColumn<string>(
                name: "Availability",
                table: "FoundPetPosts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Availability",
                table: "FoundPetPosts");

            migrationBuilder.RenameColumn(
                name: "Details",
                table: "FoundPetPosts",
                newName: "Comment");

            migrationBuilder.AddColumn<DateTime>(
                name: "AvailabilityEnd",
                table: "FoundPetPosts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "AvailabilityStart",
                table: "FoundPetPosts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
