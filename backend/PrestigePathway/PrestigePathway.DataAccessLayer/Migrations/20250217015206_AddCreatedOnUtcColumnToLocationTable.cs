using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PrestigePathway.DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class AddCreatedOnUtcColumnToLocationTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOnUtc",
                table: "StaffAssistant",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedOnUtc",
                table: "StaffAssistant",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOnUtc",
                table: "Locations",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETUTCDATE()");

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedOnUtc",
                table: "Locations",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedOnUtc",
                table: "StaffAssistant");

            migrationBuilder.DropColumn(
                name: "ModifiedOnUtc",
                table: "StaffAssistant");

            migrationBuilder.DropColumn(
                name: "CreatedOnUtc",
                table: "Locations");

            migrationBuilder.DropColumn(
                name: "ModifiedOnUtc",
                table: "Locations");
        }
    }
}
