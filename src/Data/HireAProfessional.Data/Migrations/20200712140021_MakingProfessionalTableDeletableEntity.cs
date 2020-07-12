using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HireAProfessional.Data.Migrations
{
    public partial class MakingProfessionalTableDeletableEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                table: "ProfessionalUsers",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "ProfessionalUsers",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_ProfessionalUsers_IsDeleted",
                table: "ProfessionalUsers",
                column: "IsDeleted");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ProfessionalUsers_IsDeleted",
                table: "ProfessionalUsers");

            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "ProfessionalUsers");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "ProfessionalUsers");
        }
    }
}
