using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AppReservasBio.Migrations
{
    /// <inheritdoc />
    public partial class CuartaMigracion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cantidad",
                table: "Reactivos");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Cantidad",
                table: "Reactivos",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
