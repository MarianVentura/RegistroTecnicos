using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RegistroTecnicos.Migrations
{
    /// <inheritdoc />
    public partial class AddTiposTecnicosTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "SueldoHora",
                table: "Tecnicos",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddColumn<int>(
                name: "TipoTecnicoId",
                table: "Tecnicos",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "TiposTecnicos",
                columns: table => new
                {
                    TipoTecnicoId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Descripcion = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposTecnicos", x => x.TipoTecnicoId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tecnicos_TipoTecnicoId",
                table: "Tecnicos",
                column: "TipoTecnicoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tecnicos_TiposTecnicos_TipoTecnicoId",
                table: "Tecnicos",
                column: "TipoTecnicoId",
                principalTable: "TiposTecnicos",
                principalColumn: "TipoTecnicoId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tecnicos_TiposTecnicos_TipoTecnicoId",
                table: "Tecnicos");

            migrationBuilder.DropTable(
                name: "TiposTecnicos");

            migrationBuilder.DropIndex(
                name: "IX_Tecnicos_TipoTecnicoId",
                table: "Tecnicos");

            migrationBuilder.DropColumn(
                name: "TipoTecnicoId",
                table: "Tecnicos");

            migrationBuilder.AlterColumn<int>(
                name: "SueldoHora",
                table: "Tecnicos",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "TEXT");
        }
    }
}
