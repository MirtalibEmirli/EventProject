using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EventProject.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class mig15 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Files_Events_UserMediaFile_EventId",
                table: "Files");

            migrationBuilder.RenameColumn(
                name: "UserMediaFile_EventId",
                table: "Files",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Files_UserMediaFile_EventId",
                table: "Files",
                newName: "IX_Files_UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Files_Users_UserId",
                table: "Files",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Files_Users_UserId",
                table: "Files");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Files",
                newName: "UserMediaFile_EventId");

            migrationBuilder.RenameIndex(
                name: "IX_Files_UserId",
                table: "Files",
                newName: "IX_Files_UserMediaFile_EventId");

            migrationBuilder.AddForeignKey(
                name: "FK_Files_Events_UserMediaFile_EventId",
                table: "Files",
                column: "UserMediaFile_EventId",
                principalTable: "Events",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
