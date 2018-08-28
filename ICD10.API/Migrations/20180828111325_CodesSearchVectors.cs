using Microsoft.EntityFrameworkCore.Migrations;
using NpgsqlTypes;

namespace ICD10.API.Migrations
{
    public partial class CodesSearchVectors : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<NpgsqlTsVector>(
                name: "SearchVector",
                table: "ICD9Codes",
                nullable: true);

            migrationBuilder.AddColumn<NpgsqlTsVector>(
                name: "SearchVector",
                table: "Codes",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ICD9Codes_SearchVector",
                table: "ICD9Codes",
                column: "SearchVector")
                .Annotation("Npgsql:IndexMethod", "GIN");

            migrationBuilder.CreateIndex(
                name: "IX_Codes_SearchVector",
                table: "Codes",
                column: "SearchVector")
                .Annotation("Npgsql:IndexMethod", "GIN");

            migrationBuilder.Sql(
        @"CREATE TRIGGER icd10code_search_vector_update BEFORE INSERT OR UPDATE
              ON ""Codes"" FOR EACH ROW EXECUTE PROCEDURE
              tsvector_update_trigger(""SearchVector"", 'pg_catalog.english', ""DiagnosisCode"", ""FullDescription"");");

            migrationBuilder.Sql(
                @"CREATE TRIGGER icd9code_search_vector_update BEFORE INSERT OR UPDATE
              ON ""ICD9Codes"" FOR EACH ROW EXECUTE PROCEDURE
              tsvector_update_trigger(""SearchVector"", 'pg_catalog.english', ""LongDescription"", ""ShortDescription"", ""Code"");");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ICD9Codes_SearchVector",
                table: "ICD9Codes");

            migrationBuilder.DropIndex(
                name: "IX_Codes_SearchVector",
                table: "Codes");

            migrationBuilder.DropColumn(
                name: "SearchVector",
                table: "ICD9Codes");

            migrationBuilder.DropColumn(
                name: "SearchVector",
                table: "Codes");

            migrationBuilder.Sql("DROP TRIGGER icd10code_search_vector");
            migrationBuilder.Sql("DROP TRIGGER icd9code_search_vector");
        }
    }
}
