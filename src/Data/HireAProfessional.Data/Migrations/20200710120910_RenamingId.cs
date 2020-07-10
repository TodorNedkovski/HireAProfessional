using Microsoft.EntityFrameworkCore.Migrations;

namespace HireAProfessional.Data.Migrations
{
    public partial class RenamingId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ProfessionalUsers",
                table: "ProfessionalUsers");

            migrationBuilder.DropColumn(
                name: "ProfessionalUserId",
                table: "ProfessionalUsers");

            migrationBuilder.AddColumn<string>(
                name: "Id",
                table: "ProfessionalUsers",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProfessionalUsers",
                table: "ProfessionalUsers",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ProfessionalUsers",
                table: "ProfessionalUsers");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "ProfessionalUsers");

            migrationBuilder.AddColumn<string>(
                name: "ProfessionalUserId",
                table: "ProfessionalUsers",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProfessionalUsers",
                table: "ProfessionalUsers",
                column: "ProfessionalUserId");
        }
    }
}
