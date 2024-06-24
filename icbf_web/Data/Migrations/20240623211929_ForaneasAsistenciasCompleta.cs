using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace icbf_web.Data.Migrations
{
    /// <inheritdoc />
    public partial class ForaneasAsistenciasCompleta : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RegistrosAsistencia_Ninos_NinoIdNino",
                table: "RegistrosAsistencia");

            migrationBuilder.DropColumn(
                name: "IdNino",
                table: "RegistrosAsistencia");

            migrationBuilder.RenameColumn(
                name: "NinoIdNino",
                table: "RegistrosAsistencia",
                newName: "NinoId");

            migrationBuilder.RenameIndex(
                name: "IX_RegistrosAsistencia_NinoIdNino",
                table: "RegistrosAsistencia",
                newName: "IX_RegistrosAsistencia_NinoId");

            migrationBuilder.AddForeignKey(
                name: "FK_RegistrosAsistencia_Ninos_NinoId",
                table: "RegistrosAsistencia",
                column: "NinoId",
                principalTable: "Ninos",
                principalColumn: "IdNino",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RegistrosAsistencia_Ninos_NinoId",
                table: "RegistrosAsistencia");

            migrationBuilder.RenameColumn(
                name: "NinoId",
                table: "RegistrosAsistencia",
                newName: "NinoIdNino");

            migrationBuilder.RenameIndex(
                name: "IX_RegistrosAsistencia_NinoId",
                table: "RegistrosAsistencia",
                newName: "IX_RegistrosAsistencia_NinoIdNino");

            migrationBuilder.AddColumn<long>(
                name: "IdNino",
                table: "RegistrosAsistencia",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddForeignKey(
                name: "FK_RegistrosAsistencia_Ninos_NinoIdNino",
                table: "RegistrosAsistencia",
                column: "NinoIdNino",
                principalTable: "Ninos",
                principalColumn: "IdNino",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
