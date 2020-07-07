using Microsoft.EntityFrameworkCore.Migrations;

namespace HireAProfessional.Data.Migrations
{
    public partial class AddingFirstLastNameColumsInProfessionalsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Professionals");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Professionals",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Professionals",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Professionals",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Professionals");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Professionals");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Professionals");

            migrationBuilder.AddColumn<int>(
                name: "Name",
                table: "Professionals",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
