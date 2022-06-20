using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace apiSupplyHelper.Migrations
{
    public partial class servicioproveedor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ServicioProveedores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    precio = table.Column<double>(type: "REAL", nullable: false),
                    ProveedorId = table.Column<int>(type: "INTEGER", nullable: false),
                    ServiciosssId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServicioProveedores", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ServicioProveedores_Proveedoress_ProveedorId",
                        column: x => x.ProveedorId,
                        principalTable: "Proveedoress",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ServicioProveedores_Servicess_ServiciosssId",
                        column: x => x.ServiciosssId,
                        principalTable: "Servicess",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ServicioProveedores_ProveedorId",
                table: "ServicioProveedores",
                column: "ProveedorId");

            migrationBuilder.CreateIndex(
                name: "IX_ServicioProveedores_ServiciosssId",
                table: "ServicioProveedores",
                column: "ServiciosssId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ServicioProveedores");
        }
    }
}
