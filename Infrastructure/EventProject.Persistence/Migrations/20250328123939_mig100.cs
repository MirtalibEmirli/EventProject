using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EventProject.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class mig100 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Files_Events_UserMediaFile_EventId",
                table: "Files");

            migrationBuilder.AddForeignKey(
                name: "FK_Files_Events_UserMediaFile_EventId",
                table: "Files",
                column: "UserMediaFile_EventId",
                principalTable: "Events",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Files_Events_UserMediaFile_EventId",
                table: "Files");

            migrationBuilder.AddForeignKey(
                name: "FK_Files_Events_UserMediaFile_EventId",
                table: "Files",
                column: "UserMediaFile_EventId",
                principalTable: "Events",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
