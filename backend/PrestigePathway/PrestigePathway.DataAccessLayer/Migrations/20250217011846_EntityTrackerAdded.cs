using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PrestigePathway.DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class EntityTrackerAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOnUtc",
                table: "Testimonials",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETUTCDATE()");

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedOnUtc",
                table: "Testimonials",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedOnUtc",
                table: "Testimonials");

            migrationBuilder.DropColumn(
                name: "ModifiedOnUtc",
                table: "Testimonials");
        }
    }
}
