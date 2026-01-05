using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WarehouseManagementSystem.IL.Migrations
{
    /// <inheritdoc />
    public partial class init5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_parties_shipments_ShipmentId",
                table: "parties");

            migrationBuilder.RenameColumn(
                name: "ShipmentId",
                table: "parties",
                newName: "ShipmentID");

            migrationBuilder.RenameIndex(
                name: "IX_parties_ShipmentId",
                table: "parties",
                newName: "IX_parties_ShipmentID");

            migrationBuilder.AlterColumn<int>(
                name: "ShipmentID",
                table: "parties",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_parties_shipments_ShipmentID",
                table: "parties",
                column: "ShipmentID",
                principalTable: "shipments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_parties_shipments_ShipmentID",
                table: "parties");

            migrationBuilder.RenameColumn(
                name: "ShipmentID",
                table: "parties",
                newName: "ShipmentId");

            migrationBuilder.RenameIndex(
                name: "IX_parties_ShipmentID",
                table: "parties",
                newName: "IX_parties_ShipmentId");

            migrationBuilder.AlterColumn<int>(
                name: "ShipmentId",
                table: "parties",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddForeignKey(
                name: "FK_parties_shipments_ShipmentId",
                table: "parties",
                column: "ShipmentId",
                principalTable: "shipments",
                principalColumn: "Id");
        }
    }
}
