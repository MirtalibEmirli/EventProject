using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EventProject.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class FixEventSeatPriceConfiguration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EventStandingZonePrices_StandingZones_StandingZoneId",
                table: "EventStandingZonePrices");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EventStandingZonePrices",
                table: "EventStandingZonePrices");

            migrationBuilder.DropIndex(
                name: "IX_EventStandingZonePrices_EventId",
                table: "EventStandingZonePrices");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EventSeatPrices",
                table: "EventSeatPrices");

            migrationBuilder.DropIndex(
                name: "IX_EventSeatPrices_SeatId",
                table: "EventSeatPrices");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "EventStandingZonePrices");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "EventStandingZonePrices");

            migrationBuilder.DropColumn(
                name: "DeletedDate",
                table: "EventStandingZonePrices");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "EventStandingZonePrices");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "EventStandingZonePrices");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "EventSeatPrices");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "EventSeatPrices");

            migrationBuilder.DropColumn(
                name: "DeletedDate",
                table: "EventSeatPrices");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "EventSeatPrices");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "EventSeatPrices");

            migrationBuilder.AddColumn<int>(
                name: "AvailableCount",
                table: "EventSeatPrices",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_EventStandingZonePrices",
                table: "EventStandingZonePrices",
                columns: new[] { "EventId", "StandingZoneId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_EventSeatPrices",
                table: "EventSeatPrices",
                columns: new[] { "SeatId", "EventId" });

            migrationBuilder.AddForeignKey(
                name: "FK_EventStandingZonePrices_StandingZones_StandingZoneId",
                table: "EventStandingZonePrices",
                column: "StandingZoneId",
                principalTable: "StandingZones",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EventStandingZonePrices_StandingZones_StandingZoneId",
                table: "EventStandingZonePrices");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EventStandingZonePrices",
                table: "EventStandingZonePrices");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EventSeatPrices",
                table: "EventSeatPrices");

            migrationBuilder.DropColumn(
                name: "AvailableCount",
                table: "EventSeatPrices");

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "EventStandingZonePrices",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "EventStandingZonePrices",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedDate",
                table: "EventStandingZonePrices",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "EventStandingZonePrices",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "EventStandingZonePrices",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "EventSeatPrices",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "EventSeatPrices",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedDate",
                table: "EventSeatPrices",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "EventSeatPrices",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "EventSeatPrices",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_EventStandingZonePrices",
                table: "EventStandingZonePrices",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EventSeatPrices",
                table: "EventSeatPrices",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_EventStandingZonePrices_EventId",
                table: "EventStandingZonePrices",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_EventSeatPrices_SeatId",
                table: "EventSeatPrices",
                column: "SeatId");

            migrationBuilder.AddForeignKey(
                name: "FK_EventStandingZonePrices_StandingZones_StandingZoneId",
                table: "EventStandingZonePrices",
                column: "StandingZoneId",
                principalTable: "StandingZones",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
