using Microsoft.EntityFrameworkCore.Migrations;

namespace _1erParcial_Aplicada2.Migrations
{
    public partial class pachi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "InscripcionesDetalle",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    InscripcionId = table.Column<int>(nullable: false),
                    AsignaturaId = table.Column<int>(nullable: false),
                    Nombre = table.Column<string>(nullable: true),
                    Creditos = table.Column<int>(nullable: false),
                    SubTotal = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InscripcionesDetalle", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InscripcionesDetalle_Inscripciones_InscripcionId",
                        column: x => x.InscripcionId,
                        principalTable: "Inscripciones",
                        principalColumn: "InscripcionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InscripcionesDetalle_InscripcionId",
                table: "InscripcionesDetalle",
                column: "InscripcionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InscripcionesDetalle");
        }
    }
}
