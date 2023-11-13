using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QueHacerHoyCultura.Migrations
{
    /// <inheritdoc />
    public partial class SegundaMigracion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_provincias",
                table: "provincias");

            migrationBuilder.RenameTable(
                name: "provincias",
                newName: "Provincias");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Provincias",
                table: "Provincias",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Provincias",
                table: "Provincias");

            migrationBuilder.RenameTable(
                name: "Provincias",
                newName: "provincias");

            migrationBuilder.AddPrimaryKey(
                name: "PK_provincias",
                table: "provincias",
                column: "Id");
        }
    }
}
