using Microsoft.EntityFrameworkCore.Migrations;

namespace PartiuFesta.Migrations
{
    public partial class Terceira : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Convite",
                table: "ParticipantesPrivados",
                newName: "Convitep");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Convitep",
                table: "ParticipantesPrivados",
                newName: "Convite");
        }
    }
}