using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AppReservasBio.Migrations
{
    /// <inheritdoc />
    public partial class QuintaMigracion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ModulosHorario",
                keyColumn: "Id",
                keyValue: 4,
                column: "Nombre",
                value: "10:15 - 11:15");

            migrationBuilder.UpdateData(
                table: "ModulosHorario",
                keyColumn: "Id",
                keyValue: 5,
                column: "Nombre",
                value: "11:20 - 12:20");

            migrationBuilder.UpdateData(
                table: "ModulosHorario",
                keyColumn: "Id",
                keyValue: 6,
                column: "Nombre",
                value: "12:25 - 13:25");

            migrationBuilder.UpdateData(
                table: "ModulosHorario",
                keyColumn: "Id",
                keyValue: 7,
                column: "Nombre",
                value: "13:30 - 14:30");

            migrationBuilder.UpdateData(
                table: "ModulosHorario",
                keyColumn: "Id",
                keyValue: 8,
                column: "Nombre",
                value: "14:35 - 15:35");

            migrationBuilder.UpdateData(
                table: "ModulosHorario",
                keyColumn: "Id",
                keyValue: 9,
                column: "Nombre",
                value: "15:40 - 16:40");

            migrationBuilder.UpdateData(
                table: "ModulosHorario",
                keyColumn: "Id",
                keyValue: 10,
                column: "Nombre",
                value: "16:45 - 17:45");

            migrationBuilder.UpdateData(
                table: "ModulosHorario",
                keyColumn: "Id",
                keyValue: 11,
                column: "Nombre",
                value: "17:50 - 18:50");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ModulosHorario",
                keyColumn: "Id",
                keyValue: 4,
                column: "Nombre",
                value: "07:00 - 08:00");

            migrationBuilder.UpdateData(
                table: "ModulosHorario",
                keyColumn: "Id",
                keyValue: 5,
                column: "Nombre",
                value: "07:00 - 08:00");

            migrationBuilder.UpdateData(
                table: "ModulosHorario",
                keyColumn: "Id",
                keyValue: 6,
                column: "Nombre",
                value: "07:00 - 08:00");

            migrationBuilder.UpdateData(
                table: "ModulosHorario",
                keyColumn: "Id",
                keyValue: 7,
                column: "Nombre",
                value: "07:00 - 08:00");

            migrationBuilder.UpdateData(
                table: "ModulosHorario",
                keyColumn: "Id",
                keyValue: 8,
                column: "Nombre",
                value: "07:00 - 08:00");

            migrationBuilder.UpdateData(
                table: "ModulosHorario",
                keyColumn: "Id",
                keyValue: 9,
                column: "Nombre",
                value: "07:00 - 08:00");

            migrationBuilder.UpdateData(
                table: "ModulosHorario",
                keyColumn: "Id",
                keyValue: 10,
                column: "Nombre",
                value: "07:00 - 08:00");

            migrationBuilder.UpdateData(
                table: "ModulosHorario",
                keyColumn: "Id",
                keyValue: 11,
                column: "Nombre",
                value: "07:00 - 08:00");
        }
    }
}
