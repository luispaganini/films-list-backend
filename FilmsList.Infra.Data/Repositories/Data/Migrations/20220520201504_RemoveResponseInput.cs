using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FilmsList.Infra.Data.Repositories.Data.Migrations
{
    public partial class RemoveResponseInput : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Response",
                table: "Movies");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Response",
                table: "Movies",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
