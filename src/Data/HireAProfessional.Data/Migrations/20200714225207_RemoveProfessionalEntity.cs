using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HireAProfessional.Data.Migrations
{
    public partial class RemoveProfessionalEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProfessionalUsers");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProfessionalUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CategoryId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProfessionalUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProfessionalUsers_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProfessionalUsers_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProfessionalUsers_CategoryId",
                table: "ProfessionalUsers",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ProfessionalUsers_IsDeleted",
                table: "ProfessionalUsers",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_ProfessionalUsers_UserId",
                table: "ProfessionalUsers",
                column: "UserId",
                unique: true,
                filter: "[UserId] IS NOT NULL");
        }
    }
}
