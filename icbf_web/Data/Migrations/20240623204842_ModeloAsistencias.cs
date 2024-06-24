using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace icbf_web.Data.Migrations
{
    /// <inheritdoc />
    public partial class ModeloAsistencias : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RegistrosAsistencia_Ninos_IdNinoNavigationIdNino",
                table: "RegistrosAsistencia");

            migrationBuilder.RenameColumn(
                name: "IdNinoNavigationIdNino",
                table: "RegistrosAsistencia",
                newName: "NinoIdNino");

            migrationBuilder.RenameIndex(
                name: "IX_RegistrosAsistencia_IdNinoNavigationIdNino",
                table: "RegistrosAsistencia",
                newName: "IX_RegistrosAsistencia_NinoIdNino");

            migrationBuilder.AddForeignKey(
                name: "FK_RegistrosAsistencia_Ninos_NinoIdNino",
                table: "RegistrosAsistencia",
                column: "NinoIdNino",
                principalTable: "Ninos",
                principalColumn: "IdNino",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RegistrosAsistencia_Ninos_NinoIdNino",
                table: "RegistrosAsistencia");

            migrationBuilder.RenameColumn(
                name: "NinoIdNino",
                table: "RegistrosAsistencia",
                newName: "IdNinoNavigationIdNino");

            migrationBuilder.RenameIndex(
                name: "IX_RegistrosAsistencia_NinoIdNino",
                table: "RegistrosAsistencia",
                newName: "IX_RegistrosAsistencia_IdNinoNavigationIdNino");

            migrationBuilder.AddForeignKey(
                name: "FK_RegistrosAsistencia_Ninos_IdNinoNavigationIdNino",
                table: "RegistrosAsistencia",
                column: "IdNinoNavigationIdNino",
                principalTable: "Ninos",
                principalColumn: "IdNino",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
