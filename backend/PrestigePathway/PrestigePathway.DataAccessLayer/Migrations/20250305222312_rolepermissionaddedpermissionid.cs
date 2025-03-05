using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PrestigePathway.DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class rolepermissionaddedpermissionid : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PermissionID",
                table: "RolePermission",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_RolePermission_PermissionID",
                table: "RolePermission",
                column: "PermissionID");

            migrationBuilder.AddForeignKey(
                name: "FK_RolePermission_Permissions_PermissionID",
                table: "RolePermission",
                column: "PermissionID",
                principalTable: "Permissions",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RolePermission_Permissions_PermissionID",
                table: "RolePermission");

            migrationBuilder.DropIndex(
                name: "IX_RolePermission_PermissionID",
                table: "RolePermission");

            migrationBuilder.DropColumn(
                name: "PermissionID",
                table: "RolePermission");
        }
    }
}
