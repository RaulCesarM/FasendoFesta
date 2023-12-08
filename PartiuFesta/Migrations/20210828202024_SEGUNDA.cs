using Microsoft.EntityFrameworkCore.Migrations;

namespace PartiuFesta.Migrations
{
    public partial class SEGUNDA : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Convite",
                table: "ParticipantesPrivados",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Convite",
                table: "ParticipantesPrivados");
        }
    }
}