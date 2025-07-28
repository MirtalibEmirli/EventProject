using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EventProject.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class SeedingAdmin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "Email", "Fistname", "IsDeleted", "Lastname", "PasswordHash", "ProfilePictureId", "Role", "UpdatedDate" },
                values: new object[] { new Guid("c42c9c85-1c24-40e4-b14e-d4c62b6606e7"), null, null, "emil@gmail.com", "Emil", false, "Abdullayev", "cf581ba3c0e3ce147b7250868997039215bf6533896975f50427645cedbed79a", null, 1, null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("c42c9c85-1c24-40e4-b14e-d4c62b6606e7"));
        }
    }
}
