using Microsoft.EntityFrameworkCore.Migrations;

namespace PergunteAqui.Infra.Data.Migrations
{
    public partial class TotalCountsMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "totalAnswers",
                table: "Questions",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "totalLikes",
                table: "Questions",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "totalLikes",
                table: "Answers",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "totalAnswers",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "totalLikes",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "totalLikes",
                table: "Answers");
        }
    }
}
