using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FilmsList.Infra.Data.Repositories.Data.Migrations
{
    public partial class IdUser_to_movie : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Movies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Movies");
        }
    }
}
