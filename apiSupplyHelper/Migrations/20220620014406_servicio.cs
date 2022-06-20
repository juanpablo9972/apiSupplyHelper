using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace apiSupplyHelper.Migrations
{
    public partial class servicio : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Servicess",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombre = table.Column<string>(type: "TEXT", nullable: false),
                    Descripcion = table.Column<string>(type: "TEXT", nullable: false),
                    CategoriaServicioId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Servicess", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Servicess_CategoriaServicios_CategoriaServicioId",
                        column: x => x.CategoriaServicioId,
                        principalTable: "CategoriaServicios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Servicess_CategoriaServicioId",
                table: "Servicess",
                column: "CategoriaServicioId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Servicess");
        }
    }
}
