using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WarehouseManagementSystem.IL.Migrations
{
    /// <inheritdoc />
    public partial class init2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CellID",
                table: "parties",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PartyID",
                table: "cellStorages",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_cellStorages_PartyID",
                table: "cellStorages",
                column: "PartyID",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_cellStorages_parties_PartyID",
                table: "cellStorages",
                column: "PartyID",
                principalTable: "parties",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_cellStorages_parties_PartyID",
                table: "cellStorages");

            migrationBuilder.DropIndex(
                name: "IX_cellStorages_PartyID",
                table: "cellStorages");

            migrationBuilder.DropColumn(
                name: "CellID",
                table: "parties");

            migrationBuilder.DropColumn(
                name: "PartyID",
                table: "cellStorages");
        }
    }
}
