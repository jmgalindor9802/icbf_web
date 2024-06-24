using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace icbf_web.Data.Migrations
{
    /// <inheritdoc />
    public partial class ActualizacionAvanceAcademico : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RegistrosAvanceAcademicos_Ninos_IdNinoNavigationIdNino",
                table: "RegistrosAvanceAcademicos");

            migrationBuilder.DropColumn(
                name: "IdNino",
                table: "RegistrosAvanceAcademicos");

            migrationBuilder.RenameColumn(
                name: "IdNinoNavigationIdNino",
                table: "RegistrosAvanceAcademicos",
                newName: "NinoId");

            migrationBuilder.RenameIndex(
                name: "IX_RegistrosAvanceAcademicos_IdNinoNavigationIdNino",
                table: "RegistrosAvanceAcademicos",
                newName: "IX_RegistrosAvanceAcademicos_NinoId");

            migrationBuilder.AddForeignKey(
                name: "FK_RegistrosAvanceAcademicos_Ninos_NinoId",
                table: "RegistrosAvanceAcademicos",
                column: "NinoId",
                principalTable: "Ninos",
                principalColumn: "IdNino",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RegistrosAvanceAcademicos_Ninos_NinoId",
                table: "RegistrosAvanceAcademicos");

            migrationBuilder.RenameColumn(
                name: "NinoId",
                table: "RegistrosAvanceAcademicos",
                newName: "IdNinoNavigationIdNino");

            migrationBuilder.RenameIndex(
                name: "IX_RegistrosAvanceAcademicos_NinoId",
                table: "RegistrosAvanceAcademicos",
                newName: "IX_RegistrosAvanceAcademicos_IdNinoNavigationIdNino");

            migrationBuilder.AddColumn<long>(
                name: "IdNino",
                table: "RegistrosAvanceAcademicos",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddForeignKey(
                name: "FK_RegistrosAvanceAcademicos_Ninos_IdNinoNavigationIdNino",
                table: "RegistrosAvanceAcademicos",
                column: "IdNinoNavigationIdNino",
                principalTable: "Ninos",
                principalColumn: "IdNino",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
