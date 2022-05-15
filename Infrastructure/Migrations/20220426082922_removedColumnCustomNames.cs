using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class removedColumnCustomNames : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AssignedVolunteers_FoundPetPosts_Post ID",
                table: "AssignedVolunteers");

            migrationBuilder.DropForeignKey(
                name: "FK_AssignedVolunteers_Users_Assigned To ID",
                table: "AssignedVolunteers");

            migrationBuilder.RenameColumn(
                name: "Last name",
                table: "Users",
                newName: "LastName");

            migrationBuilder.RenameColumn(
                name: "First name",
                table: "Users",
                newName: "FirstName");

            migrationBuilder.RenameColumn(
                name: "Cip ID",
                table: "FoundPetPosts",
                newName: "CipId");

            migrationBuilder.RenameColumn(
                name: "Available untill",
                table: "FoundPetPosts",
                newName: "AvailabilityEnd");

            migrationBuilder.RenameColumn(
                name: "Available from",
                table: "FoundPetPosts",
                newName: "AvailabilityStart");

            migrationBuilder.RenameColumn(
                name: "Scheduled time",
                table: "AssignedVolunteers",
                newName: "ScheduledTime");

            migrationBuilder.RenameColumn(
                name: "Post ID",
                table: "AssignedVolunteers",
                newName: "PostId");

            migrationBuilder.RenameColumn(
                name: "Assignment status",
                table: "AssignedVolunteers",
                newName: "AssignedStatus");

            migrationBuilder.RenameColumn(
                name: "Assigned To ID",
                table: "AssignedVolunteers",
                newName: "AssignedToId");

            migrationBuilder.RenameIndex(
                name: "IX_AssignedVolunteers_Post ID",
                table: "AssignedVolunteers",
                newName: "IX_AssignedVolunteers_PostId");

            migrationBuilder.RenameIndex(
                name: "IX_AssignedVolunteers_Assigned To ID",
                table: "AssignedVolunteers",
                newName: "IX_AssignedVolunteers_AssignedToId");

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

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "Users",
                newName: "Last name");

            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "Users",
                newName: "First name");

            migrationBuilder.RenameColumn(
                name: "CipId",
                table: "FoundPetPosts",
                newName: "Cip ID");

            migrationBuilder.RenameColumn(
                name: "AvailabilityStart",
                table: "FoundPetPosts",
                newName: "Available from");

            migrationBuilder.RenameColumn(
                name: "AvailabilityEnd",
                table: "FoundPetPosts",
                newName: "Available untill");

            migrationBuilder.RenameColumn(
                name: "ScheduledTime",
                table: "AssignedVolunteers",
                newName: "Scheduled time");

            migrationBuilder.RenameColumn(
                name: "PostId",
                table: "AssignedVolunteers",
                newName: "Post ID");

            migrationBuilder.RenameColumn(
                name: "AssignedToId",
                table: "AssignedVolunteers",
                newName: "Assigned To ID");

            migrationBuilder.RenameColumn(
                name: "AssignedStatus",
                table: "AssignedVolunteers",
                newName: "Assignment status");

            migrationBuilder.RenameIndex(
                name: "IX_AssignedVolunteers_PostId",
                table: "AssignedVolunteers",
                newName: "IX_AssignedVolunteers_Post ID");

            migrationBuilder.RenameIndex(
                name: "IX_AssignedVolunteers_AssignedToId",
                table: "AssignedVolunteers",
                newName: "IX_AssignedVolunteers_Assigned To ID");

            migrationBuilder.AddForeignKey(
                name: "FK_AssignedVolunteers_FoundPetPosts_Post ID",
                table: "AssignedVolunteers",
                column: "Post ID",
                principalTable: "FoundPetPosts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AssignedVolunteers_Users_Assigned To ID",
                table: "AssignedVolunteers",
                column: "Assigned To ID",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
