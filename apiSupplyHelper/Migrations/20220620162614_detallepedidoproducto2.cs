using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace apiSupplyHelper.Migrations
{
    public partial class detallepedidoproducto2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_detallePedidoProducto_Pedidos_PedidoId",
                table: "detallePedidoProducto");

            migrationBuilder.DropForeignKey(
                name: "FK_detallePedidoProducto_ProductoProveedores_ProductoProveedorId",
                table: "detallePedidoProducto");

            migrationBuilder.DropPrimaryKey(
                name: "PK_detallePedidoProducto",
                table: "detallePedidoProducto");

            migrationBuilder.RenameTable(
                name: "detallePedidoProducto",
                newName: "detallePedidoProductos");

            migrationBuilder.RenameIndex(
                name: "IX_detallePedidoProducto_ProductoProveedorId",
                table: "detallePedidoProductos",
                newName: "IX_detallePedidoProductos_ProductoProveedorId");

            migrationBuilder.RenameIndex(
                name: "IX_detallePedidoProducto_PedidoId",
                table: "detallePedidoProductos",
                newName: "IX_detallePedidoProductos_PedidoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_detallePedidoProductos",
                table: "detallePedidoProductos",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_detallePedidoProductos_Pedidos_PedidoId",
                table: "detallePedidoProductos",
                column: "PedidoId",
                principalTable: "Pedidos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_detallePedidoProductos_ProductoProveedores_ProductoProveedorId",
                table: "detallePedidoProductos",
                column: "ProductoProveedorId",
                principalTable: "ProductoProveedores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_detallePedidoProductos_Pedidos_PedidoId",
                table: "detallePedidoProductos");

            migrationBuilder.DropForeignKey(
                name: "FK_detallePedidoProductos_ProductoProveedores_ProductoProveedorId",
                table: "detallePedidoProductos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_detallePedidoProductos",
                table: "detallePedidoProductos");

            migrationBuilder.RenameTable(
                name: "detallePedidoProductos",
                newName: "detallePedidoProducto");

            migrationBuilder.RenameIndex(
                name: "IX_detallePedidoProductos_ProductoProveedorId",
                table: "detallePedidoProducto",
                newName: "IX_detallePedidoProducto_ProductoProveedorId");

            migrationBuilder.RenameIndex(
                name: "IX_detallePedidoProductos_PedidoId",
                table: "detallePedidoProducto",
                newName: "IX_detallePedidoProducto_PedidoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_detallePedidoProducto",
                table: "detallePedidoProducto",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_detallePedidoProducto_Pedidos_PedidoId",
                table: "detallePedidoProducto",
                column: "PedidoId",
                principalTable: "Pedidos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_detallePedidoProducto_ProductoProveedores_ProductoProveedorId",
                table: "detallePedidoProducto",
                column: "ProductoProveedorId",
                principalTable: "ProductoProveedores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
