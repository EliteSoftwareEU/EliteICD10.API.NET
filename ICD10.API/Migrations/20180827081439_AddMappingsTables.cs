using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ICD10.API.Migrations
{
    public partial class AddMappingsTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ICD10CodeWithMappings",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    ICD10CodeId = table.Column<Guid>(nullable: false),
                    ICD9TOICD10MappingId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ICD10CodeWithMappings", x => x.ID);
                   
                });

            migrationBuilder.CreateTable(
                name: "ICD9CodeWithMappings",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    ICD9CodeId = table.Column<Guid>(nullable: false),
                    ICD10TOICD9MappingId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ICD9CodeWithMappings", x => x.ID);
                   
                });

            migrationBuilder.CreateIndex(
                name: "IX_ICD10CodeWithMappings_ICD10CodeId",
                table: "ICD10CodeWithMappings",
                column: "ICD10CodeId");

            migrationBuilder.CreateIndex(
                name: "IX_ICD10CodeWithMappings_ICD9TOICD10MappingId",
                table: "ICD10CodeWithMappings",
                column: "ICD9TOICD10MappingId");

            migrationBuilder.CreateIndex(
                name: "IX_ICD9CodeWithMappings_ICD10TOICD9MappingId",
                table: "ICD9CodeWithMappings",
                column: "ICD10TOICD9MappingId");

            migrationBuilder.CreateIndex(
                name: "IX_ICD9CodeWithMappings_ICD9CodeId",
                table: "ICD9CodeWithMappings",
                column: "ICD9CodeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ICD10CodeWithMappings");

            migrationBuilder.DropTable(
                name: "ICD9CodeWithMappings");
        }
    }
}
