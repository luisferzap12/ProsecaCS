using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Proseca.API.Migrations
{
    /// <inheritdoc />
    public partial class identificadorAnimal : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ganados");

            migrationBuilder.AddColumn<string>(
                name: "Chapeta",
                table: "Animales",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Chapeta",
                table: "Animales");

            migrationBuilder.CreateTable(
                name: "Ganados",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cantidad = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Tipo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ganados", x => x.Id);
                });
        }
    }
}
