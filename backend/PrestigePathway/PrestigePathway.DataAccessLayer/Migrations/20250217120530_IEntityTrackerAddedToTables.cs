using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PrestigePathway.DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class IEntityTrackerAddedToTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOnUtc",
                table: "StaffAssistant",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETUTCDATE()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOnUtc",
                table: "Staff",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETUTCDATE()");

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedOnUtc",
                table: "Staff",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOnUtc",
                table: "Services",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETUTCDATE()");

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedOnUtc",
                table: "Services",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOnUtc",
                table: "ServicePartners",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETUTCDATE()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOnUtc",
                table: "ServiceOptions",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETUTCDATE()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOnUtc",
                table: "ServiceLocations",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETUTCDATE()");

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedOnUtc",
                table: "ServiceLocations",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOnUtc",
                table: "ServiceDetails",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETUTCDATE()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOnUtc",
                table: "Promotions",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETUTCDATE()");

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedOnUtc",
                table: "Promotions",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOnUtc",
                table: "Payments",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETUTCDATE()");

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedOnUtc",
                table: "Payments",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOnUtc",
                table: "Partners",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETUTCDATE()");

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedOnUtc",
                table: "Partners",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOnUtc",
                table: "Clients",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETUTCDATE()");

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedOnUtc",
                table: "Clients",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOnUtc",
                table: "Bookings",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETUTCDATE()");

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedOnUtc",
                table: "Bookings",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedOnUtc",
                table: "Staff");

            migrationBuilder.DropColumn(
                name: "ModifiedOnUtc",
                table: "Staff");

            migrationBuilder.DropColumn(
                name: "CreatedOnUtc",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "ModifiedOnUtc",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "CreatedOnUtc",
                table: "ServiceLocations");

            migrationBuilder.DropColumn(
                name: "ModifiedOnUtc",
                table: "ServiceLocations");

            migrationBuilder.DropColumn(
                name: "CreatedOnUtc",
                table: "Promotions");

            migrationBuilder.DropColumn(
                name: "ModifiedOnUtc",
                table: "Promotions");

            migrationBuilder.DropColumn(
                name: "CreatedOnUtc",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "ModifiedOnUtc",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "CreatedOnUtc",
                table: "Partners");

            migrationBuilder.DropColumn(
                name: "ModifiedOnUtc",
                table: "Partners");

            migrationBuilder.DropColumn(
                name: "CreatedOnUtc",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "ModifiedOnUtc",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "CreatedOnUtc",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "ModifiedOnUtc",
                table: "Bookings");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOnUtc",
                table: "StaffAssistant",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "GETUTCDATE()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOnUtc",
                table: "ServicePartners",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "GETUTCDATE()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOnUtc",
                table: "ServiceOptions",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "GETUTCDATE()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOnUtc",
                table: "ServiceDetails",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "GETUTCDATE()");
        }
    }
}
