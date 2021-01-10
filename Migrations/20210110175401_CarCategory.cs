using Microsoft.EntityFrameworkCore.Migrations;

namespace Chirila_Luisa_Lab9.Migrations
{
    public partial class CarCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ManufactureID",
                table: "Car",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Manufacture",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ManufactureName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Manufacture", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "CarCategory",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CarID = table.Column<int>(nullable: false),
                    CategoryID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarCategory", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CarCategory_Car_CarID",
                        column: x => x.CarID,
                        principalTable: "Car",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CarCategory_Category_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "Category",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Car_ManufactureID",
                table: "Car",
                column: "ManufactureID");

            migrationBuilder.CreateIndex(
                name: "IX_CarCategory_CarID",
                table: "CarCategory",
                column: "CarID");

            migrationBuilder.CreateIndex(
                name: "IX_CarCategory_CategoryID",
                table: "CarCategory",
                column: "CategoryID");

            migrationBuilder.AddForeignKey(
                name: "FK_Car_Manufacture_ManufactureID",
                table: "Car",
                column: "ManufactureID",
                principalTable: "Manufacture",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Car_Manufacture_ManufactureID",
                table: "Car");

            migrationBuilder.DropTable(
                name: "CarCategory");

            migrationBuilder.DropTable(
                name: "Manufacture");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropIndex(
                name: "IX_Car_ManufactureID",
                table: "Car");

            migrationBuilder.DropColumn(
                name: "ManufactureID",
                table: "Car");
        }
    }
}
