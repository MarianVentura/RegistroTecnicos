using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RegistroTecnicos.Migrations
{
    /// <inheritdoc />
    public partial class AddTiposTecnicosToTecnicos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tecnicos_TiposTecnicos_TipoTecnicoId",
                table: "Tecnicos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TiposTecnicos",
                table: "TiposTecnicos");

            migrationBuilder.RenameColumn(
                name: "TipoTecnicoId",
                table: "TiposTecnicos",
                newName: "Activo");

            migrationBuilder.RenameColumn(
                name: "TipoTecnicoId",
                table: "Tecnicos",
                newName: "TiposTecnicosId");

            migrationBuilder.RenameIndex(
                name: "IX_Tecnicos_TipoTecnicoId",
                table: "Tecnicos",
                newName: "IX_Tecnicos_TiposTecnicosId");

            migrationBuilder.AlterColumn<bool>(
                name: "Activo",
                table: "TiposTecnicos",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddColumn<int>(
                name: "TiposTecnicosId",
                table: "TiposTecnicos",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0)
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_TiposTecnicos",
                table: "TiposTecnicos",
                column: "TiposTecnicosId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tecnicos_TiposTecnicos_TiposTecnicosId",
                table: "Tecnicos",
                column: "TiposTecnicosId",
                principalTable: "TiposTecnicos",
                principalColumn: "TiposTecnicosId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tecnicos_TiposTecnicos_TiposTecnicosId",
                table: "Tecnicos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TiposTecnicos",
                table: "TiposTecnicos");

            migrationBuilder.DropColumn(
                name: "TiposTecnicosId",
                table: "TiposTecnicos");

            migrationBuilder.RenameColumn(
                name: "Activo",
                table: "TiposTecnicos",
                newName: "TipoTecnicoId");

            migrationBuilder.RenameColumn(
                name: "TiposTecnicosId",
                table: "Tecnicos",
                newName: "TipoTecnicoId");

            migrationBuilder.RenameIndex(
                name: "IX_Tecnicos_TiposTecnicosId",
                table: "Tecnicos",
                newName: "IX_Tecnicos_TipoTecnicoId");

            migrationBuilder.AlterColumn<int>(
                name: "TipoTecnicoId",
                table: "TiposTecnicos",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "INTEGER")
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_TiposTecnicos",
                table: "TiposTecnicos",
                column: "TipoTecnicoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tecnicos_TiposTecnicos_TipoTecnicoId",
                table: "Tecnicos",
                column: "TipoTecnicoId",
                principalTable: "TiposTecnicos",
                principalColumn: "TipoTecnicoId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
