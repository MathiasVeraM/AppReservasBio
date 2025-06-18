using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AppReservasBio.Migrations
{
    /// <inheritdoc />
    public partial class ModificacionesMantenimientoAdmin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "EsMantenimiento",
                table: "Reservas",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<TimeSpan>(
                name: "HoraFinMantenimiento",
                table: "Reservas",
                type: "time",
                nullable: true);

            migrationBuilder.AddColumn<TimeSpan>(
                name: "HoraInicioMantenimiento",
                table: "Reservas",
                type: "time",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UsuarioId",
                table: "Reservas",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EsMantenimiento",
                table: "Reservas");

            migrationBuilder.DropColumn(
                name: "HoraFinMantenimiento",
                table: "Reservas");

            migrationBuilder.DropColumn(
                name: "HoraInicioMantenimiento",
                table: "Reservas");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "Reservas");
        }
    }
}
