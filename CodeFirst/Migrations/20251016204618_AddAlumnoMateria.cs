using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CodeFirst.Migrations
{
    /// <inheritdoc />
    public partial class AddAlumnoMateria : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Materias_Alumnos_AlumnoId",
                table: "Materias");

            migrationBuilder.DropIndex(
                name: "IX_Materias_AlumnoId",
                table: "Materias");

            migrationBuilder.DropColumn(
                name: "AlumnoId",
                table: "Materias");

            migrationBuilder.CreateTable(
                name: "AlumnoMaterias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    AlumnoId = table.Column<int>(type: "int", nullable: false),
                    MateriaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlumnoMaterias", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AlumnoMaterias_Alumnos_AlumnoId",
                        column: x => x.AlumnoId,
                        principalTable: "Alumnos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AlumnoMaterias_Materias_MateriaId",
                        column: x => x.MateriaId,
                        principalTable: "Materias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_AlumnoMaterias_AlumnoId",
                table: "AlumnoMaterias",
                column: "AlumnoId");

            migrationBuilder.CreateIndex(
                name: "IX_AlumnoMaterias_MateriaId",
                table: "AlumnoMaterias",
                column: "MateriaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AlumnoMaterias");

            migrationBuilder.AddColumn<int>(
                name: "AlumnoId",
                table: "Materias",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Materias_AlumnoId",
                table: "Materias",
                column: "AlumnoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Materias_Alumnos_AlumnoId",
                table: "Materias",
                column: "AlumnoId",
                principalTable: "Alumnos",
                principalColumn: "Id");
        }
    }
}
