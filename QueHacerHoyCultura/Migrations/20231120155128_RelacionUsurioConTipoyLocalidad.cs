using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QueHacerHoyCultura.Migrations
{
    /// <inheritdoc />
    public partial class RelacionUsurioConTipoyLocalidad : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Localidad",
                table: "Usuarios",
                newName: "TipoUsuarioId");

            migrationBuilder.RenameColumn(
                name: "IdTipoUsuario",
                table: "Usuarios",
                newName: "LocalidadId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_LocalidadId",
                table: "Usuarios",
                column: "LocalidadId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_TipoUsuarioId",
                table: "Usuarios",
                column: "TipoUsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Usuarios_Localidades_LocalidadId",
                table: "Usuarios",
                column: "LocalidadId",
                principalTable: "Localidades",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Usuarios_TipoUsuarios_TipoUsuarioId",
                table: "Usuarios",
                column: "TipoUsuarioId",
                principalTable: "TipoUsuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Usuarios_Localidades_LocalidadId",
                table: "Usuarios");

            migrationBuilder.DropForeignKey(
                name: "FK_Usuarios_TipoUsuarios_TipoUsuarioId",
                table: "Usuarios");

            migrationBuilder.DropIndex(
                name: "IX_Usuarios_LocalidadId",
                table: "Usuarios");

            migrationBuilder.DropIndex(
                name: "IX_Usuarios_TipoUsuarioId",
                table: "Usuarios");

            migrationBuilder.RenameColumn(
                name: "TipoUsuarioId",
                table: "Usuarios",
                newName: "Localidad");

            migrationBuilder.RenameColumn(
                name: "LocalidadId",
                table: "Usuarios",
                newName: "IdTipoUsuario");
        }
    }
}
