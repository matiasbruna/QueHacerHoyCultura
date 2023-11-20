using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QueHacerHoyCultura.Migrations
{
    /// <inheritdoc />
    public partial class RelacionProvonciaLocalidad : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IdProvincia",
                table: "Localidades",
                newName: "ProvinciaId");

            migrationBuilder.CreateIndex(
                name: "IX_Localidades_ProvinciaId",
                table: "Localidades",
                column: "ProvinciaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Localidades_Provincias_ProvinciaId",
                table: "Localidades",
                column: "ProvinciaId",
                principalTable: "Provincias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Localidades_Provincias_ProvinciaId",
                table: "Localidades");

            migrationBuilder.DropIndex(
                name: "IX_Localidades_ProvinciaId",
                table: "Localidades");

            migrationBuilder.RenameColumn(
                name: "ProvinciaId",
                table: "Localidades",
                newName: "IdProvincia");
        }
    }
}
