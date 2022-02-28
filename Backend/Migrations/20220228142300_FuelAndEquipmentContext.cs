using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend.Migrations
{
    public partial class FuelAndEquipmentContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VehicleEquipment_Vehicles_VehicleVIN",
                table: "VehicleEquipment");

            migrationBuilder.DropForeignKey(
                name: "FK_Vehicles_FuelType_FuelID",
                table: "Vehicles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_VehicleEquipment",
                table: "VehicleEquipment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FuelType",
                table: "FuelType");

            migrationBuilder.RenameTable(
                name: "VehicleEquipment",
                newName: "Equipment");

            migrationBuilder.RenameTable(
                name: "FuelType",
                newName: "FuelTypes");

            migrationBuilder.RenameIndex(
                name: "IX_VehicleEquipment_VehicleVIN",
                table: "Equipment",
                newName: "IX_Equipment_VehicleVIN");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Equipment",
                table: "Equipment",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FuelTypes",
                table: "FuelTypes",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Equipment_Vehicles_VehicleVIN",
                table: "Equipment",
                column: "VehicleVIN",
                principalTable: "Vehicles",
                principalColumn: "VIN");

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicles_FuelTypes_FuelID",
                table: "Vehicles",
                column: "FuelID",
                principalTable: "FuelTypes",
                principalColumn: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Equipment_Vehicles_VehicleVIN",
                table: "Equipment");

            migrationBuilder.DropForeignKey(
                name: "FK_Vehicles_FuelTypes_FuelID",
                table: "Vehicles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FuelTypes",
                table: "FuelTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Equipment",
                table: "Equipment");

            migrationBuilder.RenameTable(
                name: "FuelTypes",
                newName: "FuelType");

            migrationBuilder.RenameTable(
                name: "Equipment",
                newName: "VehicleEquipment");

            migrationBuilder.RenameIndex(
                name: "IX_Equipment_VehicleVIN",
                table: "VehicleEquipment",
                newName: "IX_VehicleEquipment_VehicleVIN");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FuelType",
                table: "FuelType",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_VehicleEquipment",
                table: "VehicleEquipment",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_VehicleEquipment_Vehicles_VehicleVIN",
                table: "VehicleEquipment",
                column: "VehicleVIN",
                principalTable: "Vehicles",
                principalColumn: "VIN");

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicles_FuelType_FuelID",
                table: "Vehicles",
                column: "FuelID",
                principalTable: "FuelType",
                principalColumn: "ID");
        }
    }
}
