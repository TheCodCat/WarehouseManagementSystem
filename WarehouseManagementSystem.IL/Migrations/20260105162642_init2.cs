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
            migrationBuilder.DropColumn(
                name: "PartyList",
                table: "shipments");

            migrationBuilder.AddColumn<int>(
                name: "ShipmentId",
                table: "parties",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_parties_ShipmentId",
                table: "parties",
                column: "ShipmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_parties_shipments_ShipmentId",
                table: "parties",
                column: "ShipmentId",
                principalTable: "shipments",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_parties_shipments_ShipmentId",
                table: "parties");

            migrationBuilder.DropIndex(
                name: "IX_parties_ShipmentId",
                table: "parties");

            migrationBuilder.DropColumn(
                name: "ShipmentId",
                table: "parties");

            migrationBuilder.AddColumn<string>(
                name: "PartyList",
                table: "shipments",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }
    }
}
