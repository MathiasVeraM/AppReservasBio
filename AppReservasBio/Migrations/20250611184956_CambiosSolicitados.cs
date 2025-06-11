using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AppReservasBio.Migrations
{
    /// <inheritdoc />
    public partial class CambiosSolicitados : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Actividad",
                table: "Reservas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ConsideracionesEspeciales",
                table: "Reservas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "DocenteId",
                table: "Reservas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "EvidenciaCorreoRuta",
                table: "Reservas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Materia",
                table: "Reservas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "NombreProyecto",
                table: "Reservas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "UnidadId",
                table: "Reactivos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Docentes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Docentes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Unidades",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Unidades", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reservas_DocenteId",
                table: "Reservas",
                column: "DocenteId");

            migrationBuilder.CreateIndex(
                name: "IX_Reactivos_UnidadId",
                table: "Reactivos",
                column: "UnidadId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reactivos_Unidades_UnidadId",
                table: "Reactivos",
                column: "UnidadId",
                principalTable: "Unidades",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservas_Docentes_DocenteId",
                table: "Reservas",
                column: "DocenteId",
                principalTable: "Docentes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reactivos_Unidades_UnidadId",
                table: "Reactivos");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservas_Docentes_DocenteId",
                table: "Reservas");

            migrationBuilder.DropTable(
                name: "Docentes");

            migrationBuilder.DropTable(
                name: "Unidades");

            migrationBuilder.DropIndex(
                name: "IX_Reservas_DocenteId",
                table: "Reservas");

            migrationBuilder.DropIndex(
                name: "IX_Reactivos_UnidadId",
                table: "Reactivos");

            migrationBuilder.DropColumn(
                name: "Actividad",
                table: "Reservas");

            migrationBuilder.DropColumn(
                name: "ConsideracionesEspeciales",
                table: "Reservas");

            migrationBuilder.DropColumn(
                name: "DocenteId",
                table: "Reservas");

            migrationBuilder.DropColumn(
                name: "EvidenciaCorreoRuta",
                table: "Reservas");

            migrationBuilder.DropColumn(
                name: "Materia",
                table: "Reservas");

            migrationBuilder.DropColumn(
                name: "NombreProyecto",
                table: "Reservas");

            migrationBuilder.DropColumn(
                name: "UnidadId",
                table: "Reactivos");
        }
    }
}
