using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WarehouseManagementSystem.IL.Migrations
{
    /// <inheritdoc />
    public partial class init3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_cellStorages_PartyID",
                table: "cellStorages");

            migrationBuilder.DropColumn(
                name: "CellID",
                table: "parties");

            migrationBuilder.CreateIndex(
                name: "IX_cellStorages_PartyID",
                table: "cellStorages",
                column: "PartyID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_cellStorages_PartyID",
                table: "cellStorages");

            migrationBuilder.AddColumn<int>(
                name: "CellID",
                table: "parties",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_cellStorages_PartyID",
                table: "cellStorages",
                column: "PartyID",
                unique: true);
        }
    }
}
