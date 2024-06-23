using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace icbf_web.Data.Migrations
{
    /// <inheritdoc />
    public partial class PrimeraMigracion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                table: "AspNetUserClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                table: "AspNetUserLogins");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                table: "AspNetUserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                table: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.CreateTable(
                name: "Jardines",
                columns: table => new
                {
                    IdJardin = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreJardin = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DireccionJardin = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    EstadoJardin = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jardines", x => x.IdJardin);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Nombres = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cedula = table.Column<long>(type: "bigint", nullable: false),
                    Telefono = table.Column<long>(type: "bigint", nullable: false),
                    Estado = table.Column<bool>(type: "bit", nullable: false),
                    FechaNacimiento = table.Column<DateOnly>(type: "date", nullable: false),
                    IdJardin = table.Column<int>(type: "int", nullable: true),
                    IdJardinNavigationIdJardin = table.Column<int>(type: "int", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Usuarios_Jardines_IdJardinNavigationIdJardin",
                        column: x => x.IdJardinNavigationIdJardin,
                        principalTable: "Jardines",
                        principalColumn: "IdJardin");
                });

            migrationBuilder.CreateTable(
                name: "Ninos",
                columns: table => new
                {
                    IdNino = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreNino = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaNacimientoNino = table.Column<DateOnly>(type: "date", nullable: false),
                    TipoSangreNino = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CiudadNacimientoNino = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdAcudiente = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TelefonoNino = table.Column<long>(type: "bigint", nullable: false),
                    DireccionNino = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EpsNino = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdJardin = table.Column<int>(type: "int", nullable: false),
                    IdAcudienteNavigationId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    IdJardinNavigationIdJardin = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ninos", x => x.IdNino);
                    table.ForeignKey(
                        name: "FK_Ninos_Jardines_IdJardinNavigationIdJardin",
                        column: x => x.IdJardinNavigationIdJardin,
                        principalTable: "Jardines",
                        principalColumn: "IdJardin",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ninos_Usuarios_IdAcudienteNavigationId",
                        column: x => x.IdAcudienteNavigationId,
                        principalTable: "Usuarios",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "RegistrosAsistencia",
                columns: table => new
                {
                    IdRegistroAsistencia = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdNino = table.Column<long>(type: "bigint", nullable: false),
                    FechaRegistro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EstadoNinoRegistro = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdNinoNavigationIdNino = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegistrosAsistencia", x => x.IdRegistroAsistencia);
                    table.ForeignKey(
                        name: "FK_RegistrosAsistencia_Ninos_IdNinoNavigationIdNino",
                        column: x => x.IdNinoNavigationIdNino,
                        principalTable: "Ninos",
                        principalColumn: "IdNino",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RegistrosAvanceAcademicos",
                columns: table => new
                {
                    IdAvance = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdNino = table.Column<long>(type: "bigint", nullable: false),
                    AnioEscolarAvance = table.Column<int>(type: "int", nullable: false),
                    NivelAvance = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NotaAvance = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DescripcionAvance = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaEntregaAvance = table.Column<DateOnly>(type: "date", nullable: false),
                    IdNinoNavigationIdNino = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegistrosAvanceAcademicos", x => x.IdAvance);
                    table.ForeignKey(
                        name: "FK_RegistrosAvanceAcademicos_Ninos_IdNinoNavigationIdNino",
                        column: x => x.IdNinoNavigationIdNino,
                        principalTable: "Ninos",
                        principalColumn: "IdNino",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ninos_IdAcudienteNavigationId",
                table: "Ninos",
                column: "IdAcudienteNavigationId");

            migrationBuilder.CreateIndex(
                name: "IX_Ninos_IdJardinNavigationIdJardin",
                table: "Ninos",
                column: "IdJardinNavigationIdJardin");

            migrationBuilder.CreateIndex(
                name: "IX_RegistrosAsistencia_IdNinoNavigationIdNino",
                table: "RegistrosAsistencia",
                column: "IdNinoNavigationIdNino");

            migrationBuilder.CreateIndex(
                name: "IX_RegistrosAvanceAcademicos_IdNinoNavigationIdNino",
                table: "RegistrosAvanceAcademicos",
                column: "IdNinoNavigationIdNino");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "Usuarios",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_IdJardinNavigationIdJardin",
                table: "Usuarios",
                column: "IdJardinNavigationIdJardin");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "Usuarios",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserClaims_Usuarios_UserId",
                table: "AspNetUserClaims",
                column: "UserId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserLogins_Usuarios_UserId",
                table: "AspNetUserLogins",
                column: "UserId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_Usuarios_UserId",
                table: "AspNetUserRoles",
                column: "UserId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserTokens_Usuarios_UserId",
                table: "AspNetUserTokens",
                column: "UserId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserClaims_Usuarios_UserId",
                table: "AspNetUserClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserLogins_Usuarios_UserId",
                table: "AspNetUserLogins");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserRoles_Usuarios_UserId",
                table: "AspNetUserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserTokens_Usuarios_UserId",
                table: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "RegistrosAsistencia");

            migrationBuilder.DropTable(
                name: "RegistrosAvanceAcademicos");

            migrationBuilder.DropTable(
                name: "Ninos");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Jardines");

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                table: "AspNetUserClaims",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                table: "AspNetUserLogins",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                table: "AspNetUserRoles",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                table: "AspNetUserTokens",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
