using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PrestigePathway.DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class AddServicePartnerTypeDetailsOptionTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ServiceTypes",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    CreatedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    ModifiedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceTypes", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ServiceOptions",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ServiceTypeID = table.Column<int>(type: "int", nullable: false),
                    OptionName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceOptions", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ServiceOptions_ServiceTypes_ServiceTypeID",
                        column: x => x.ServiceTypeID,
                        principalTable: "ServiceTypes",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "ServicePartners",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PartnerName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    ServiceTypeID = table.Column<int>(type: "int", nullable: false),
                    ServiceOptionID = table.Column<int>(type: "int", nullable: false),
                    ContactEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactPhone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServicePartners", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ServicePartners_ServiceOptions_ServiceOptionID",
                        column: x => x.ServiceOptionID,
                        principalTable: "ServiceOptions",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_ServicePartners_ServiceTypes_ServiceTypeID",
                        column: x => x.ServiceTypeID,
                        principalTable: "ServiceTypes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ServiceDetails",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ServiceName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ServicePartnerID = table.Column<int>(type: "int", nullable: false),
                    ServiceTypeID = table.Column<int>(type: "int", nullable: false),
                    ServiceOptionID = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreatedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceDetails", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ServiceDetails_ServiceOptions_ServiceOptionID",
                        column: x => x.ServiceOptionID,
                        principalTable: "ServiceOptions",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_ServiceDetails_ServicePartners_ServicePartnerID",
                        column: x => x.ServicePartnerID,
                        principalTable: "ServicePartners",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ServiceDetails_ServiceTypes_ServiceTypeID",
                        column: x => x.ServiceTypeID,
                        principalTable: "ServiceTypes",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ServiceDetails_ServiceOptionID",
                table: "ServiceDetails",
                column: "ServiceOptionID");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceDetails_ServicePartnerID",
                table: "ServiceDetails",
                column: "ServicePartnerID");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceDetails_ServiceTypeID",
                table: "ServiceDetails",
                column: "ServiceTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceOptions_ServiceTypeID",
                table: "ServiceOptions",
                column: "ServiceTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_ServicePartners_ServiceOptionID",
                table: "ServicePartners",
                column: "ServiceOptionID");

            migrationBuilder.CreateIndex(
                name: "IX_ServicePartners_ServiceTypeID",
                table: "ServicePartners",
                column: "ServiceTypeID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ServiceDetails");

            migrationBuilder.DropTable(
                name: "ServicePartners");

            migrationBuilder.DropTable(
                name: "ServiceOptions");

            migrationBuilder.DropTable(
                name: "ServiceTypes");
        }
    }
}
