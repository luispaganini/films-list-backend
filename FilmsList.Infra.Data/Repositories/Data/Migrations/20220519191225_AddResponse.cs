using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FilmsList.Infra.Data.Repositories.Data.Migrations
{
    public partial class AddResponse : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "PriorityLevel",
                table: "Movies",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<bool>(
                name: "Response",
                table: "Movies",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Response",
                table: "Movies");

            migrationBuilder.AlterColumn<int>(
                name: "PriorityLevel",
                table: "Movies",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }
    }
}
