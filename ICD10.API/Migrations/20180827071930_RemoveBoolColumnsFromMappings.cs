using Microsoft.EntityFrameworkCore.Migrations;

namespace ICD10.API.Migrations
{
    public partial class RemoveBoolColumnsFromMappings : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Approximate",
                table: "ICD9TOICD10Mappings");

            migrationBuilder.DropColumn(
                name: "ChoiceList",
                table: "ICD9TOICD10Mappings");

            migrationBuilder.DropColumn(
                name: "Combination",
                table: "ICD9TOICD10Mappings");

            migrationBuilder.DropColumn(
                name: "NoMapping",
                table: "ICD9TOICD10Mappings");

            migrationBuilder.DropColumn(
                name: "Scenario",
                table: "ICD9TOICD10Mappings");

            migrationBuilder.DropColumn(
                name: "Approximate",
                table: "ICD10TOICD9Mappings");

            migrationBuilder.DropColumn(
                name: "ChoiceList",
                table: "ICD10TOICD9Mappings");

            migrationBuilder.DropColumn(
                name: "Combination",
                table: "ICD10TOICD9Mappings");

            migrationBuilder.DropColumn(
                name: "NoMapping",
                table: "ICD10TOICD9Mappings");

            migrationBuilder.DropColumn(
                name: "Scenario",
                table: "ICD10TOICD9Mappings");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Approximate",
                table: "ICD9TOICD10Mappings",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "ChoiceList",
                table: "ICD9TOICD10Mappings",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Combination",
                table: "ICD9TOICD10Mappings",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "NoMapping",
                table: "ICD9TOICD10Mappings",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Scenario",
                table: "ICD9TOICD10Mappings",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Approximate",
                table: "ICD10TOICD9Mappings",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "ChoiceList",
                table: "ICD10TOICD9Mappings",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Combination",
                table: "ICD10TOICD9Mappings",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "NoMapping",
                table: "ICD10TOICD9Mappings",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Scenario",
                table: "ICD10TOICD9Mappings",
                nullable: false,
                defaultValue: false);
        }
    }
}
