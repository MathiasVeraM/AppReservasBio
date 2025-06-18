using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AppReservasBio.Migrations
{
    /// <inheritdoc />
    public partial class ValidacionesReservasMantenimiento : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservas_Docentes_DocenteId",
                table: "Reservas");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservas_ModulosHorario_ModuloHorarioId",
                table: "Reservas");

            migrationBuilder.AlterColumn<string>(
                name: "NombreProyecto",
                table: "Reservas",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "ModuloHorarioId",
                table: "Reservas",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Materia",
                table: "Reservas",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "EvidenciaCorreoRuta",
                table: "Reservas",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "DocenteId",
                table: "Reservas",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "ConsideracionesEspeciales",
                table: "Reservas",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Actividad",
                table: "Reservas",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservas_Docentes_DocenteId",
                table: "Reservas",
                column: "DocenteId",
                principalTable: "Docentes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservas_ModulosHorario_ModuloHorarioId",
                table: "Reservas",
                column: "ModuloHorarioId",
                principalTable: "ModulosHorario",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservas_Docentes_DocenteId",
                table: "Reservas");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservas_ModulosHorario_ModuloHorarioId",
                table: "Reservas");

            migrationBuilder.AlterColumn<string>(
                name: "NombreProyecto",
                table: "Reservas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ModuloHorarioId",
                table: "Reservas",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Materia",
                table: "Reservas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "EvidenciaCorreoRuta",
                table: "Reservas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DocenteId",
                table: "Reservas",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ConsideracionesEspeciales",
                table: "Reservas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Actividad",
                table: "Reservas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservas_Docentes_DocenteId",
                table: "Reservas",
                column: "DocenteId",
                principalTable: "Docentes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservas_ModulosHorario_ModuloHorarioId",
                table: "Reservas",
                column: "ModuloHorarioId",
                principalTable: "ModulosHorario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
