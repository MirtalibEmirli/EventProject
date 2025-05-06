using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EventProject.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class mig16 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TicketSold",
                table: "StandingZones");

            migrationBuilder.AddColumn<Guid>(
                name: "VenueId",
                table: "StandingZones",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "EventStandingZonePrices",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EventId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StandingZoneId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Price = table.Column<float>(type: "real", nullable: false),
                    AvailableCount = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventStandingZonePrices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EventStandingZonePrices_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EventStandingZonePrices_StandingZones_StandingZoneId",
                        column: x => x.StandingZoneId,
                        principalTable: "StandingZones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StandingZones_VenueId",
                table: "StandingZones",
                column: "VenueId");

            migrationBuilder.CreateIndex(
                name: "IX_EventStandingZonePrices_EventId",
                table: "EventStandingZonePrices",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_EventStandingZonePrices_StandingZoneId",
                table: "EventStandingZonePrices",
                column: "StandingZoneId");

            migrationBuilder.AddForeignKey(
                name: "FK_StandingZones_Venues_VenueId",
                table: "StandingZones",
                column: "VenueId",
                principalTable: "Venues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StandingZones_Venues_VenueId",
                table: "StandingZones");

            migrationBuilder.DropTable(
                name: "EventStandingZonePrices");

            migrationBuilder.DropIndex(
                name: "IX_StandingZones_VenueId",
                table: "StandingZones");

            migrationBuilder.DropColumn(
                name: "VenueId",
                table: "StandingZones");

            migrationBuilder.AddColumn<int>(
                name: "TicketSold",
                table: "StandingZones",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
