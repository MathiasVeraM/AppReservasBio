using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AppReservasBio.Migrations
{
    /// <inheritdoc />
    public partial class PrimeraMigracion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Equipos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Laboratorios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Laboratorios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ModulosHorario",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HoraInicio = table.Column<TimeSpan>(type: "time", nullable: false),
                    HoraFin = table.Column<TimeSpan>(type: "time", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModulosHorario", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Reactivos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cantidad = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reactivos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Reservas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModuloHorarioId = table.Column<int>(type: "int", nullable: false),
                    LaboratorioId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reservas_Laboratorios_LaboratorioId",
                        column: x => x.LaboratorioId,
                        principalTable: "Laboratorios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reservas_ModulosHorario_ModuloHorarioId",
                        column: x => x.ModuloHorarioId,
                        principalTable: "ModulosHorario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EquipoReserva",
                columns: table => new
                {
                    EquiposId = table.Column<int>(type: "int", nullable: false),
                    ReservaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EquipoReserva", x => new { x.EquiposId, x.ReservaId });
                    table.ForeignKey(
                        name: "FK_EquipoReserva_Equipos_EquiposId",
                        column: x => x.EquiposId,
                        principalTable: "Equipos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EquipoReserva_Reservas_ReservaId",
                        column: x => x.ReservaId,
                        principalTable: "Reservas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Estudiantes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cedula = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Correo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReservaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estudiantes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Estudiantes_Reservas_ReservaId",
                        column: x => x.ReservaId,
                        principalTable: "Reservas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ReactivoReserva",
                columns: table => new
                {
                    ReactivosId = table.Column<int>(type: "int", nullable: false),
                    ReservaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReactivoReserva", x => new { x.ReactivosId, x.ReservaId });
                    table.ForeignKey(
                        name: "FK_ReactivoReserva_Reactivos_ReactivosId",
                        column: x => x.ReactivosId,
                        principalTable: "Reactivos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReactivoReserva_Reservas_ReservaId",
                        column: x => x.ReservaId,
                        principalTable: "Reservas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ModulosHorario",
                columns: new[] { "Id", "HoraFin", "HoraInicio", "Nombre" },
                values: new object[,]
                {
                    { 1, new TimeSpan(0, 8, 0, 0, 0), new TimeSpan(0, 7, 0, 0, 0), "07:00 - 08:00" },
                    { 2, new TimeSpan(0, 9, 5, 0, 0), new TimeSpan(0, 8, 5, 0, 0), "08:05 - 09:05" },
                    { 3, new TimeSpan(0, 10, 10, 0, 0), new TimeSpan(0, 9, 10, 0, 0), "09:10 - 10:10" },
                    { 4, new TimeSpan(0, 11, 15, 0, 0), new TimeSpan(0, 10, 15, 0, 0), "07:00 - 08:00" },
                    { 5, new TimeSpan(0, 12, 20, 0, 0), new TimeSpan(0, 11, 20, 0, 0), "07:00 - 08:00" },
                    { 6, new TimeSpan(0, 13, 25, 0, 0), new TimeSpan(0, 12, 25, 0, 0), "07:00 - 08:00" },
                    { 7, new TimeSpan(0, 14, 30, 0, 0), new TimeSpan(0, 13, 30, 0, 0), "07:00 - 08:00" },
                    { 8, new TimeSpan(0, 15, 35, 0, 0), new TimeSpan(0, 14, 35, 0, 0), "07:00 - 08:00" },
                    { 9, new TimeSpan(0, 16, 40, 0, 0), new TimeSpan(0, 15, 40, 0, 0), "07:00 - 08:00" },
                    { 10, new TimeSpan(0, 17, 45, 0, 0), new TimeSpan(0, 16, 45, 0, 0), "07:00 - 08:00" },
                    { 11, new TimeSpan(0, 18, 50, 0, 0), new TimeSpan(0, 17, 50, 0, 0), "07:00 - 08:00" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_EquipoReserva_ReservaId",
                table: "EquipoReserva",
                column: "ReservaId");

            migrationBuilder.CreateIndex(
                name: "IX_Estudiantes_ReservaId",
                table: "Estudiantes",
                column: "ReservaId");

            migrationBuilder.CreateIndex(
                name: "IX_ReactivoReserva_ReservaId",
                table: "ReactivoReserva",
                column: "ReservaId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservas_LaboratorioId",
                table: "Reservas",
                column: "LaboratorioId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservas_ModuloHorarioId",
                table: "Reservas",
                column: "ModuloHorarioId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EquipoReserva");

            migrationBuilder.DropTable(
                name: "Estudiantes");

            migrationBuilder.DropTable(
                name: "ReactivoReserva");

            migrationBuilder.DropTable(
                name: "Equipos");

            migrationBuilder.DropTable(
                name: "Reactivos");

            migrationBuilder.DropTable(
                name: "Reservas");

            migrationBuilder.DropTable(
                name: "Laboratorios");

            migrationBuilder.DropTable(
                name: "ModulosHorario");
        }
    }
}
