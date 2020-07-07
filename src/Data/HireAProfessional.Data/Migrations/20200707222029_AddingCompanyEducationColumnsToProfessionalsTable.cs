using Microsoft.EntityFrameworkCore.Migrations;

namespace HireAProfessional.Data.Migrations
{
    public partial class AddingCompanyEducationColumnsToProfessionalsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Company",
                table: "Professionals",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Education",
                table: "Professionals",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FacebookAccountLink",
                table: "Professionals",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LinkedInAccountLink",
                table: "Professionals",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TwitterAccountLink",
                table: "Professionals",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Company",
                table: "Professionals");

            migrationBuilder.DropColumn(
                name: "Education",
                table: "Professionals");

            migrationBuilder.DropColumn(
                name: "FacebookAccountLink",
                table: "Professionals");

            migrationBuilder.DropColumn(
                name: "LinkedInAccountLink",
                table: "Professionals");

            migrationBuilder.DropColumn(
                name: "TwitterAccountLink",
                table: "Professionals");
        }
    }
}
