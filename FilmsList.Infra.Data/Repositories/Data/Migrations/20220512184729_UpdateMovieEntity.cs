using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FilmsList.Infra.Data.Repositories.Data.Migrations
{
    public partial class UpdateMovieEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RatingMovie",
                table: "Movies",
                newName: "Score");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Score",
                table: "Movies",
                newName: "RatingMovie");
        }
    }
}
