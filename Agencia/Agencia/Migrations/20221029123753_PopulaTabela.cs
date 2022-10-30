using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Agencia.Migrations
{
    public partial class PopulaTabela : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Destinos",
                columns: new[] { "Id", "CidadeNome", "Pais" },
                values: new object[] { 1, "Beijing", "CHN" });

            migrationBuilder.InsertData(
                table: "Destinos",
                columns: new[] { "Id", "CidadeNome", "Pais" },
                values: new object[] { 2, "Mountain View", "USA" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Destinos",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Destinos",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
