using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace apiSupplyHelper.Migrations
{
    public partial class productoproveedor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProductoProveedores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    precioUnitario = table.Column<double>(type: "REAL", nullable: false),
                    pesoUnitario = table.Column<double>(type: "REAL", nullable: false),
                    cantidadMinima = table.Column<double>(type: "REAL", nullable: false),
                    unidadMedida = table.Column<string>(type: "TEXT", nullable: false),
                    Presentacion = table.Column<string>(type: "TEXT", nullable: false),
                    ProveedorId = table.Column<int>(type: "INTEGER", nullable: false),
                    ProductoId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductoProveedores", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductoProveedores_Products_ProductoId",
                        column: x => x.ProductoId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductoProveedores_Proveedoress_ProveedorId",
                        column: x => x.ProveedorId,
                        principalTable: "Proveedoress",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductoProveedores_ProductoId",
                table: "ProductoProveedores",
                column: "ProductoId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductoProveedores_ProveedorId",
                table: "ProductoProveedores",
                column: "ProveedorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductoProveedores");
        }
    }
}
