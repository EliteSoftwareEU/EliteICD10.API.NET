using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ICD10.API.Migrations
{
    public partial class CreateCategoriesAndCodes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    Code = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Codes",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    ICD10CategoryId = table.Column<Guid>(nullable: false),
                    DiagnosisCode = table.Column<string>(nullable: true),
                    AbbreviatedDescription = table.Column<string>(nullable: true),
                    FullDescription = table.Column<string>(nullable: true)
                });

            migrationBuilder.CreateIndex(
                name: "IX_Codes_ICD10CategoryId",
                table: "Codes",
                column: "ICD10CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Codes");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
