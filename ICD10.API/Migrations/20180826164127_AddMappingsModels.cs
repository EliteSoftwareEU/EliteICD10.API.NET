using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ICD10.API.Migrations
{
    public partial class AddMappingsModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ICD10TOICD9Mappings",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    ICD9Code = table.Column<string>(nullable: true),
                    ICD10Code = table.Column<string>(nullable: true),
                    Flags = table.Column<string>(nullable: true),
                    Approximate = table.Column<bool>(nullable: false),
                    NoMapping = table.Column<bool>(nullable: false),
                    Combination = table.Column<bool>(nullable: false),
                    Scenario = table.Column<bool>(nullable: false),
                    ChoiceList = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ICD10TOICD9Mappings", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ICD9TOICD10Mappings",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    ICD9Code = table.Column<string>(nullable: true),
                    ICD10Code = table.Column<string>(nullable: true),
                    Flags = table.Column<string>(nullable: true),
                    Approximate = table.Column<bool>(nullable: false),
                    NoMapping = table.Column<bool>(nullable: false),
                    Combination = table.Column<bool>(nullable: false),
                    Scenario = table.Column<bool>(nullable: false),
                    ChoiceList = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ICD9TOICD10Mappings", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ICD10TOICD9Mappings");

            migrationBuilder.DropTable(
                name: "ICD9TOICD10Mappings");
        }
    }
}
