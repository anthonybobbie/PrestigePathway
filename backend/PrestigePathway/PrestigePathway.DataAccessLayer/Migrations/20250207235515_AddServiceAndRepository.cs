using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PrestigePathway.DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class AddServiceAndRepository : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_ServiceAbstractions_ServiceID",
                table: "Bookings");

            migrationBuilder.DropForeignKey(
                name: "FK_Promotions_ServiceAbstractions_ServiceID",
                table: "Promotions");

            migrationBuilder.DropForeignKey(
                name: "FK_ServiceLocations_ServiceAbstractions_ServiceID",
                table: "ServiceLocations");

            migrationBuilder.DropTable(
                name: "ServiceAbstractions");

            migrationBuilder.CreateTable(
                name: "Services",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ServiceName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    DurationHours = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    PartnerID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Services", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Services_Partners_PartnerID",
                        column: x => x.PartnerID,
                        principalTable: "Partners",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Services_PartnerID",
                table: "Services",
                column: "PartnerID");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Username",
                table: "Users",
                column: "Username",
                unique: true,
                filter: "[Username] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Services_ServiceID",
                table: "Bookings",
                column: "ServiceID",
                principalTable: "Services",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Promotions_Services_ServiceID",
                table: "Promotions",
                column: "ServiceID",
                principalTable: "Services",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceLocations_Services_ServiceID",
                table: "ServiceLocations",
                column: "ServiceID",
                principalTable: "Services",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Services_ServiceID",
                table: "Bookings");

            migrationBuilder.DropForeignKey(
                name: "FK_Promotions_Services_ServiceID",
                table: "Promotions");

            migrationBuilder.DropForeignKey(
                name: "FK_ServiceLocations_Services_ServiceID",
                table: "ServiceLocations");

            migrationBuilder.DropTable(
                name: "Services");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.CreateTable(
                name: "ServiceAbstractions",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DurationHours = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    PartnerID = table.Column<int>(type: "int", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    ServiceName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceAbstractions", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ServiceAbstractions_Partners_PartnerID",
                        column: x => x.PartnerID,
                        principalTable: "Partners",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ServiceAbstractions_PartnerID",
                table: "ServiceAbstractions",
                column: "PartnerID");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_ServiceAbstractions_ServiceID",
                table: "Bookings",
                column: "ServiceID",
                principalTable: "ServiceAbstractions",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Promotions_ServiceAbstractions_ServiceID",
                table: "Promotions",
                column: "ServiceID",
                principalTable: "ServiceAbstractions",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceLocations_ServiceAbstractions_ServiceID",
                table: "ServiceLocations",
                column: "ServiceID",
                principalTable: "ServiceAbstractions",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
