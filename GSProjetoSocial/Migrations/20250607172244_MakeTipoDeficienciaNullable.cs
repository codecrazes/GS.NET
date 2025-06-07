using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GSProjetoSocial.Migrations
{
    /// <inheritdoc />
    public partial class MakeTipoDeficienciaNullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "TipoDeficiencia",
                table: "FormulariosFamilia",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "FormulariosFamilia",
                keyColumn: "TipoDeficiencia",
                keyValue: null,
                column: "TipoDeficiencia",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "TipoDeficiencia",
                table: "FormulariosFamilia",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");
        }
    }
}
