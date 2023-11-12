using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigrate1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_asignatura_profesor_IdProfesorFk",
                table: "asignatura");

            migrationBuilder.AlterColumn<int>(
                name: "IdProfesorFk",
                table: "asignatura",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_asignatura_profesor_IdProfesorFk",
                table: "asignatura",
                column: "IdProfesorFk",
                principalTable: "profesor",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_asignatura_profesor_IdProfesorFk",
                table: "asignatura");

            migrationBuilder.AlterColumn<int>(
                name: "IdProfesorFk",
                table: "asignatura",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_asignatura_profesor_IdProfesorFk",
                table: "asignatura",
                column: "IdProfesorFk",
                principalTable: "profesor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
