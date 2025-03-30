using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EventProject.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class mig7 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Seats_Venues_VenueId1",
                table: "Seats");

            migrationBuilder.DropIndex(
                name: "IX_Seats_VenueId1",
                table: "Seats");

            migrationBuilder.DropColumn(
                name: "VenueId1",
                table: "Seats");

            migrationBuilder.AddColumn<Guid>(
                name: "UserMediaFile_EventId",
                table: "Files",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Files_UserMediaFile_EventId",
                table: "Files",
                column: "UserMediaFile_EventId");

            migrationBuilder.AddForeignKey(
                name: "FK_Files_Events_UserMediaFile_EventId",
                table: "Files",
                column: "UserMediaFile_EventId",
                principalTable: "Events",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Files_Events_UserMediaFile_EventId",
                table: "Files");

            migrationBuilder.DropIndex(
                name: "IX_Files_UserMediaFile_EventId",
                table: "Files");

            migrationBuilder.DropColumn(
                name: "UserMediaFile_EventId",
                table: "Files");

            migrationBuilder.AddColumn<Guid>(
                name: "VenueId1",
                table: "Seats",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Seats_VenueId1",
                table: "Seats",
                column: "VenueId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Seats_Venues_VenueId1",
                table: "Seats",
                column: "VenueId1",
                principalTable: "Venues",
                principalColumn: "Id");
        }
    }
}
