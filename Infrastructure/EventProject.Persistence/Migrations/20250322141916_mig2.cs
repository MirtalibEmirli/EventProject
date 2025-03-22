using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EventProject.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class mig2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "RotationY",
                table: "Seats",
                type: "real",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "VenueId1",
                table: "Seats",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "X",
                table: "Seats",
                type: "real",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "Y",
                table: "Seats",
                type: "real",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "Z",
                table: "Seats",
                type: "real",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "VenueId",
                table: "Events",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "EventSeatPrices",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EventId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SeatId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Price = table.Column<float>(type: "real", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventSeatPrices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EventSeatPrices_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EventSeatPrices_Seats_SeatId",
                        column: x => x.SeatId,
                        principalTable: "Seats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SectionWeights",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VenueId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SectionName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Weight = table.Column<float>(type: "real", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SectionWeights", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SectionWeights_Venues_VenueId",
                        column: x => x.VenueId,
                        principalTable: "Venues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Seats_VenueId1",
                table: "Seats",
                column: "VenueId1");

            migrationBuilder.CreateIndex(
                name: "IX_Events_VenueId",
                table: "Events",
                column: "VenueId");

            migrationBuilder.CreateIndex(
                name: "IX_EventSeatPrices_EventId",
                table: "EventSeatPrices",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_EventSeatPrices_SeatId",
                table: "EventSeatPrices",
                column: "SeatId");

            migrationBuilder.CreateIndex(
                name: "IX_SectionWeights_VenueId",
                table: "SectionWeights",
                column: "VenueId");

            migrationBuilder.AddForeignKey(
                name: "FK_Events_Venues_VenueId",
                table: "Events",
                column: "VenueId",
                principalTable: "Venues",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Seats_Venues_VenueId1",
                table: "Seats",
                column: "VenueId1",
                principalTable: "Venues",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Events_Venues_VenueId",
                table: "Events");

            migrationBuilder.DropForeignKey(
                name: "FK_Seats_Venues_VenueId1",
                table: "Seats");

            migrationBuilder.DropTable(
                name: "EventSeatPrices");

            migrationBuilder.DropTable(
                name: "SectionWeights");

            migrationBuilder.DropIndex(
                name: "IX_Seats_VenueId1",
                table: "Seats");

            migrationBuilder.DropIndex(
                name: "IX_Events_VenueId",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "RotationY",
                table: "Seats");

            migrationBuilder.DropColumn(
                name: "VenueId1",
                table: "Seats");

            migrationBuilder.DropColumn(
                name: "X",
                table: "Seats");

            migrationBuilder.DropColumn(
                name: "Y",
                table: "Seats");

            migrationBuilder.DropColumn(
                name: "Z",
                table: "Seats");

            migrationBuilder.DropColumn(
                name: "VenueId",
                table: "Events");
        }
    }
}
