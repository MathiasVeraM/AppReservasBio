using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AppReservasBio.Migrations
{
    /// <inheritdoc />
    public partial class TerceraMigracion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ReactivoReserva");

            migrationBuilder.CreateTable(
                name: "ReservaReactivos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReservaId = table.Column<int>(type: "int", nullable: false),
                    ReactivoId = table.Column<int>(type: "int", nullable: false),
                    Cantidad = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReservaReactivos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReservaReactivos_Reactivos_ReactivoId",
                        column: x => x.ReactivoId,
                        principalTable: "Reactivos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReservaReactivos_Reservas_ReservaId",
                        column: x => x.ReservaId,
                        principalTable: "Reservas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ReservaReactivos_ReactivoId",
                table: "ReservaReactivos",
                column: "ReactivoId");

            migrationBuilder.CreateIndex(
                name: "IX_ReservaReactivos_ReservaId",
                table: "ReservaReactivos",
                column: "ReservaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ReservaReactivos");

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

            migrationBuilder.CreateIndex(
                name: "IX_ReactivoReserva_ReservaId",
                table: "ReactivoReserva",
                column: "ReservaId");
        }
    }
}
