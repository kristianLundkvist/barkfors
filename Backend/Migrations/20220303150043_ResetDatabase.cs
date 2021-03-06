using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend.Migrations
{
    public partial class ResetDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BrandSet",
                columns: table => new
                {
                    BrandName = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BrandSet", x => x.BrandName);
                });

            migrationBuilder.CreateTable(
                name: "Colors",
                columns: table => new
                {
                    ColorName = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Colors", x => x.ColorName);
                });

            migrationBuilder.CreateTable(
                name: "Equipment",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Equipment = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipment", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "EquipmentLists",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VIN = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EquipmentID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EquipmentLists", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "FuelTypes",
                columns: table => new
                {
                    Type = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FuelTypes", x => x.Type);
                });

            migrationBuilder.CreateTable(
                name: "Vehicles",
                columns: table => new
                {
                    VIN = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LicensePlate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BrandName = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CarColorColorName = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    FuelTypeType = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicles", x => x.VIN);
                    table.ForeignKey(
                        name: "FK_Vehicles_BrandSet_BrandName",
                        column: x => x.BrandName,
                        principalTable: "BrandSet",
                        principalColumn: "BrandName");
                    table.ForeignKey(
                        name: "FK_Vehicles_Colors_CarColorColorName",
                        column: x => x.CarColorColorName,
                        principalTable: "Colors",
                        principalColumn: "ColorName");
                    table.ForeignKey(
                        name: "FK_Vehicles_FuelTypes_FuelTypeType",
                        column: x => x.FuelTypeType,
                        principalTable: "FuelTypes",
                        principalColumn: "Type");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_BrandName",
                table: "Vehicles",
                column: "BrandName");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_CarColorColorName",
                table: "Vehicles",
                column: "CarColorColorName");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_FuelTypeType",
                table: "Vehicles",
                column: "FuelTypeType");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Equipment");

            migrationBuilder.DropTable(
                name: "EquipmentLists");

            migrationBuilder.DropTable(
                name: "Vehicles");

            migrationBuilder.DropTable(
                name: "BrandSet");

            migrationBuilder.DropTable(
                name: "Colors");

            migrationBuilder.DropTable(
                name: "FuelTypes");
        }
    }
}
