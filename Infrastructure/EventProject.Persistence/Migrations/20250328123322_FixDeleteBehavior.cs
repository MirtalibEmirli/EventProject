using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EventProject.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class FixDeleteBehavior : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Events_Venues_VenueId",
                table: "Events");

            migrationBuilder.DropForeignKey(
                name: "FK_Files_Events_EventId",
                table: "Files");

            migrationBuilder.DropForeignKey(
                name: "FK_Seats_Venues_VenueId",
                table: "Seats");

            migrationBuilder.DropIndex(
                name: "IX_Events_VenueId",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "VenueId",
                table: "Events");

            migrationBuilder.AddColumn<Guid>(
                name: "UserId1",
                table: "Notifications",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_UserId1",
                table: "Notifications",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Files_Events_EventId",
                table: "Files",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Notifications_Users_UserId1",
                table: "Notifications",
                column: "UserId1",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Seats_Venues_VenueId",
                table: "Seats",
                column: "VenueId",
                principalTable: "Venues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Files_Events_EventId",
                table: "Files");

            migrationBuilder.DropForeignKey(
                name: "FK_Notifications_Users_UserId1",
                table: "Notifications");

            migrationBuilder.DropForeignKey(
                name: "FK_Seats_Venues_VenueId",
                table: "Seats");

            migrationBuilder.DropIndex(
                name: "IX_Notifications_UserId1",
                table: "Notifications");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "Notifications");

            migrationBuilder.AddColumn<Guid>(
                name: "VenueId",
                table: "Events",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Events_VenueId",
                table: "Events",
                column: "VenueId");

            migrationBuilder.AddForeignKey(
                name: "FK_Events_Venues_VenueId",
                table: "Events",
                column: "VenueId",
                principalTable: "Venues",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Files_Events_EventId",
                table: "Files",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Seats_Venues_VenueId",
                table: "Seats",
                column: "VenueId",
                principalTable: "Venues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
