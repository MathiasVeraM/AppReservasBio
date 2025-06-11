using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AppReservasBio.Migrations
{
    /// <inheritdoc />
    public partial class ModificacionesUnidades : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reactivos_Unidades_UnidadId",
                table: "Reactivos");

            migrationBuilder.AddColumn<string>(
                name: "Unidad",
                table: "ReservaReactivos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<int>(
                name: "UnidadId",
                table: "Reactivos",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Reactivos_Unidades_UnidadId",
                table: "Reactivos",
                column: "UnidadId",
                principalTable: "Unidades",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reactivos_Unidades_UnidadId",
                table: "Reactivos");

            migrationBuilder.DropColumn(
                name: "Unidad",
                table: "ReservaReactivos");

            migrationBuilder.AlterColumn<int>(
                name: "UnidadId",
                table: "Reactivos",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Reactivos_Unidades_UnidadId",
                table: "Reactivos",
                column: "UnidadId",
                principalTable: "Unidades",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
