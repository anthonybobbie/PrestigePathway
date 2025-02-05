using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PrestigePathway.DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class RenamedPrimaryKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TestimonialID",
                table: "Testimonials",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "StaffAssistantID",
                table: "StaffAssistant",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "StaffID",
                table: "Staff",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "ServiceID",
                table: "Services",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "ServiceLocationID",
                table: "ServiceLocations",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "PromotionID",
                table: "Promotions",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "PaymentID",
                table: "Payments",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "PartnerID",
                table: "Partners",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "LocationID",
                table: "Locations",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "ClientID",
                table: "Clients",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "BookingID",
                table: "Bookings",
                newName: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Testimonials",
                newName: "TestimonialID");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "StaffAssistant",
                newName: "StaffAssistantID");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Staff",
                newName: "StaffID");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Services",
                newName: "ServiceID");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "ServiceLocations",
                newName: "ServiceLocationID");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Promotions",
                newName: "PromotionID");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Payments",
                newName: "PaymentID");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Partners",
                newName: "PartnerID");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Locations",
                newName: "LocationID");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Clients",
                newName: "ClientID");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Bookings",
                newName: "BookingID");
        }
    }
}
