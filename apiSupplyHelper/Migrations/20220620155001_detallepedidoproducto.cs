using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace apiSupplyHelper.Migrations
{
    public partial class detallepedidoproducto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "detallePedidoProducto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Cantidad = table.Column<double>(type: "REAL", nullable: false),
                    Subtotal = table.Column<double>(type: "REAL", nullable: false),
                    PedidoId = table.Column<int>(type: "INTEGER", nullable: false),
                    ProductoProveedorId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_detallePedidoProducto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_detallePedidoProducto_Pedidos_PedidoId",
                        column: x => x.PedidoId,
                        principalTable: "Pedidos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_detallePedidoProducto_ProductoProveedores_ProductoProveedorId",
                        column: x => x.ProductoProveedorId,
                        principalTable: "ProductoProveedores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_detallePedidoProducto_PedidoId",
                table: "detallePedidoProducto",
                column: "PedidoId");

            migrationBuilder.CreateIndex(
                name: "IX_detallePedidoProducto_ProductoProveedorId",
                table: "detallePedidoProducto",
                column: "ProductoProveedorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "detallePedidoProducto");
        }
    }
}
