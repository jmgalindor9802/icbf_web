using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace icbf_web.Data.Migrations
{
    /// <inheritdoc />
    public partial class ForaneasNino : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ninos_Jardines_IdJardinNavigationIdJardin",
                table: "Ninos");

            migrationBuilder.DropForeignKey(
                name: "FK_Ninos_Usuarios_IdAcudienteNavigationId",
                table: "Ninos");

            migrationBuilder.DropIndex(
                name: "IX_Ninos_IdAcudienteNavigationId",
                table: "Ninos");

            migrationBuilder.DropIndex(
                name: "IX_Ninos_IdJardinNavigationIdJardin",
                table: "Ninos");

            migrationBuilder.DropColumn(
                name: "IdAcudienteNavigationId",
                table: "Ninos");

            migrationBuilder.DropColumn(
                name: "IdJardinNavigationIdJardin",
                table: "Ninos");

            migrationBuilder.AlterColumn<string>(
                name: "IdAcudiente",
                table: "Ninos",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "DireccionJardin",
                table: "Jardines",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.CreateIndex(
                name: "IX_Ninos_IdAcudiente",
                table: "Ninos",
                column: "IdAcudiente");

            migrationBuilder.CreateIndex(
                name: "IX_Ninos_IdJardin",
                table: "Ninos",
                column: "IdJardin");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ninos_Jardines_IdJardin",
                table: "Ninos");

            migrationBuilder.DropForeignKey(
                name: "FK_Ninos_Usuarios_IdAcudiente",
                table: "Ninos");

            migrationBuilder.DropIndex(
                name: "IX_Ninos_IdAcudiente",
                table: "Ninos");

            migrationBuilder.DropIndex(
                name: "IX_Ninos_IdJardin",
                table: "Ninos");

            migrationBuilder.AlterColumn<string>(
                name: "IdAcudiente",
                table: "Ninos",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "IdAcudienteNavigationId",
                table: "Ninos",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdJardinNavigationIdJardin",
                table: "Ninos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "DireccionJardin",
                table: "Jardines",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_Ninos_IdAcudienteNavigationId",
                table: "Ninos",
                column: "IdAcudienteNavigationId");

            migrationBuilder.CreateIndex(
                name: "IX_Ninos_IdJardinNavigationIdJardin",
                table: "Ninos",
                column: "IdJardinNavigationIdJardin");

            migrationBuilder.AddForeignKey(
                name: "FK_Ninos_Jardines_IdJardinNavigationIdJardin",
                table: "Ninos",
                column: "IdJardinNavigationIdJardin",
                principalTable: "Jardines",
                principalColumn: "IdJardin",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ninos_Usuarios_IdAcudienteNavigationId",
                table: "Ninos",
                column: "IdAcudienteNavigationId",
                principalTable: "Usuarios",
                principalColumn: "Id");
        }
    }
}
