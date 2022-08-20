using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EscolaAPI.Infra.Migrations
{
    public partial class AddNomeProfessor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Nome",
                table: "Professores",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Nome",
                table: "Professores");
        }
    }
}
