using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace icbf_web.Data.Migrations
{
    /// <inheritdoc />
    public partial class QuitarForaneasDuplicadas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ninos_Jardines_IdJardin",
                table: "Ninos");

            migrationBuilder.DropForeignKey(
                name: "FK_Ninos_Usuarios_IdAcudiente",
                table: "Ninos");

            migrationBuilder.RenameColumn(
                name: "IdJardin",
                table: "Ninos",
                newName: "JardinId");

            migrationBuilder.RenameColumn(
                name: "IdAcudiente",
                table: "Ninos",
                newName: "UsuarioId");

            migrationBuilder.RenameIndex(
                name: "IX_Ninos_IdJardin",
                table: "Ninos",
                newName: "IX_Ninos_JardinId");

            migrationBuilder.RenameIndex(
                name: "IX_Ninos_IdAcudiente",
                table: "Ninos",
                newName: "IX_Ninos_UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ninos_Jardines_JardinId",
                table: "Ninos",
                column: "JardinId",
                principalTable: "Jardines",
                principalColumn: "IdJardin",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ninos_Usuarios_UsuarioId",
                table: "Ninos",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ninos_Jardines_JardinId",
                table: "Ninos");

            migrationBuilder.DropForeignKey(
                name: "FK_Ninos_Usuarios_UsuarioId",
                table: "Ninos");

            migrationBuilder.RenameColumn(
                name: "UsuarioId",
                table: "Ninos",
                newName: "IdAcudiente");

            migrationBuilder.RenameColumn(
                name: "JardinId",
                table: "Ninos",
                newName: "IdJardin");

            migrationBuilder.RenameIndex(
                name: "IX_Ninos_UsuarioId",
                table: "Ninos",
                newName: "IX_Ninos_IdAcudiente");

            migrationBuilder.RenameIndex(
                name: "IX_Ninos_JardinId",
                table: "Ninos",
                newName: "IX_Ninos_IdJardin");

            migrationBuilder.AddForeignKey(
                name: "FK_Ninos_Jardines_IdJardin",
                table: "Ninos",
                column: "IdJardin",
                principalTable: "Jardines",
                principalColumn: "IdJardin",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ninos_Usuarios_IdAcudiente",
                table: "Ninos",
                column: "IdAcudiente",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
