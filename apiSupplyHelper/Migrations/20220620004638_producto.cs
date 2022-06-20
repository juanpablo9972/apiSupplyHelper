using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace apiSupplyHelper.Migrations
{
    public partial class producto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombre = table.Column<string>(type: "TEXT", nullable: false),
                    Descripcion = table.Column<string>(type: "TEXT", nullable: false),
                    CategoriaProductoId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_CategoriaProductos_CategoriaProductoId",
                        column: x => x.CategoriaProductoId,
                        principalTable: "CategoriaProductos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoriaProductoId",
                table: "Products",
                column: "CategoriaProductoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
