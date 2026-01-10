using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WarehouseManagementSystem.IL.Migrations
{
    /// <inheritdoc />
    public partial class addparty : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_cellStorages_parties_PartyID",
                table: "cellStorages");

            migrationBuilder.DropIndex(
                name: "IX_cellStorages_PartyID",
                table: "cellStorages");

            migrationBuilder.DropColumn(
                name: "PartyID",
                table: "cellStorages");

            migrationBuilder.AddColumn<int>(
                name: "CellID",
                table: "parties",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_parties_CellID",
                table: "parties",
                column: "CellID");

            migrationBuilder.AddForeignKey(
                name: "FK_parties_cellStorages_CellID",
                table: "parties",
                column: "CellID",
                principalTable: "cellStorages",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_parties_cellStorages_CellID",
                table: "parties");

            migrationBuilder.DropIndex(
                name: "IX_parties_CellID",
                table: "parties");

            migrationBuilder.DropColumn(
                name: "CellID",
                table: "parties");

            migrationBuilder.AddColumn<int>(
                name: "PartyID",
                table: "cellStorages",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_cellStorages_PartyID",
                table: "cellStorages",
                column: "PartyID");

            migrationBuilder.AddForeignKey(
                name: "FK_cellStorages_parties_PartyID",
                table: "cellStorages",
                column: "PartyID",
                principalTable: "parties",
                principalColumn: "Id");
        }
    }
}
