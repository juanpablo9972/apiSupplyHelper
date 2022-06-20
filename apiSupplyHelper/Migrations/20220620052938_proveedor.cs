using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace apiSupplyHelper.Migrations
{
    public partial class proveedor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProveedorId",
                table: "Agentes",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Proveedoress",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombre = table.Column<string>(type: "TEXT", nullable: false),
                    Direccion = table.Column<string>(type: "TEXT", nullable: false),
                    Telefono = table.Column<string>(type: "TEXT", nullable: false),
                    Correo = table.Column<string>(type: "TEXT", nullable: false),
                    Pais = table.Column<string>(type: "TEXT", nullable: false),
                    CodigoPostal = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proveedoress", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Agentes_ProveedorId",
                table: "Agentes",
                column: "ProveedorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Agentes_Proveedoress_ProveedorId",
                table: "Agentes",
                column: "ProveedorId",
                principalTable: "Proveedoress",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Agentes_Proveedoress_ProveedorId",
                table: "Agentes");

            migrationBuilder.DropTable(
                name: "Proveedoress");

            migrationBuilder.DropIndex(
                name: "IX_Agentes_ProveedorId",
                table: "Agentes");

            migrationBuilder.DropColumn(
                name: "ProveedorId",
                table: "Agentes");
        }
    }
}
