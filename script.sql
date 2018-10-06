CREATE TABLE IF NOT EXISTS "__EFMigrationsHistory" (
    "MigrationId" varchar(150) NOT NULL,
    "ProductVersion" varchar(32) NOT NULL,
    CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY ("MigrationId")
);

CREATE TABLE "Categories" (
    "ID" uuid NOT NULL,
    "Code" text NULL,
    "Title" text NULL,
    CONSTRAINT "PK_Categories" PRIMARY KEY ("ID")
);

CREATE TABLE "Codes" (
    "ID" uuid NOT NULL,
    "ICD10CategoryId" uuid NOT NULL,
    "DiagnosisCode" text NULL,
    "AbbreviatedDescription" text NULL,
    "FullDescription" text NULL
);

CREATE INDEX "IX_Codes_ICD10CategoryId" ON "Codes" ("ICD10CategoryId");

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20180823100350_CreateCategoriesAndCodes', '2.1.1-rtm-30846');

CREATE TABLE "ICD9Codes" (
    "ID" uuid NOT NULL,
    "Code" text NULL,
    "LongDescription" text NULL,
    "ShortDescription" text NULL,
    "Version" integer NOT NULL,
    CONSTRAINT "PK_ICD9Codes" PRIMARY KEY ("ID")
);

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20180826152824_AddICD9Codes', '2.1.1-rtm-30846');

CREATE TABLE "ICD10TOICD9Mappings" (
    "ID" uuid NOT NULL,
    "ICD9Code" text NULL,
    "ICD10Code" text NULL,
    "Flags" text NULL,
    "Approximate" boolean NOT NULL,
    "NoMapping" boolean NOT NULL,
    "Combination" boolean NOT NULL,
    "Scenario" boolean NOT NULL,
    "ChoiceList" boolean NOT NULL,
    CONSTRAINT "PK_ICD10TOICD9Mappings" PRIMARY KEY ("ID")
);

CREATE TABLE "ICD9TOICD10Mappings" (
    "ID" uuid NOT NULL,
    "ICD9Code" text NULL,
    "ICD10Code" text NULL,
    "Flags" text NULL,
    "Approximate" boolean NOT NULL,
    "NoMapping" boolean NOT NULL,
    "Combination" boolean NOT NULL,
    "Scenario" boolean NOT NULL,
    "ChoiceList" boolean NOT NULL,
    CONSTRAINT "PK_ICD9TOICD10Mappings" PRIMARY KEY ("ID")
);

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20180826164127_AddMappingsModels', '2.1.1-rtm-30846');

ALTER TABLE "ICD9TOICD10Mappings" DROP COLUMN "Approximate";

ALTER TABLE "ICD9TOICD10Mappings" DROP COLUMN "ChoiceList";

ALTER TABLE "ICD9TOICD10Mappings" DROP COLUMN "Combination";

ALTER TABLE "ICD9TOICD10Mappings" DROP COLUMN "NoMapping";

ALTER TABLE "ICD9TOICD10Mappings" DROP COLUMN "Scenario";

ALTER TABLE "ICD10TOICD9Mappings" DROP COLUMN "Approximate";

ALTER TABLE "ICD10TOICD9Mappings" DROP COLUMN "ChoiceList";

ALTER TABLE "ICD10TOICD9Mappings" DROP COLUMN "Combination";

ALTER TABLE "ICD10TOICD9Mappings" DROP COLUMN "NoMapping";

ALTER TABLE "ICD10TOICD9Mappings" DROP COLUMN "Scenario";

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20180827071930_RemoveBoolColumnsFromMappings', '2.1.1-rtm-30846');

CREATE TABLE "ICD10CodeWithMappings" (
    "ID" uuid NOT NULL,
    "ICD10CodeId" uuid NOT NULL,
    "ICD9TOICD10MappingId" uuid NOT NULL,
    CONSTRAINT "PK_ICD10CodeWithMappings" PRIMARY KEY ("ID")
);

CREATE TABLE "ICD9CodeWithMappings" (
    "ID" uuid NOT NULL,
    "ICD9CodeId" uuid NOT NULL,
    "ICD10TOICD9MappingId" uuid NOT NULL,
    CONSTRAINT "PK_ICD9CodeWithMappings" PRIMARY KEY ("ID")
);

CREATE INDEX "IX_ICD10CodeWithMappings_ICD10CodeId" ON "ICD10CodeWithMappings" ("ICD10CodeId");

CREATE INDEX "IX_ICD10CodeWithMappings_ICD9TOICD10MappingId" ON "ICD10CodeWithMappings" ("ICD9TOICD10MappingId");

CREATE INDEX "IX_ICD9CodeWithMappings_ICD10TOICD9MappingId" ON "ICD9CodeWithMappings" ("ICD10TOICD9MappingId");

CREATE INDEX "IX_ICD9CodeWithMappings_ICD9CodeId" ON "ICD9CodeWithMappings" ("ICD9CodeId");

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20180827081439_AddMappingsTables', '2.1.1-rtm-30846');

ALTER TABLE "ICD9Codes" ADD "SearchVector" tsvector NULL;

ALTER TABLE "Codes" ADD "SearchVector" tsvector NULL;

CREATE INDEX "IX_ICD9Codes_SearchVector" ON "ICD9Codes" USING GIN ("SearchVector");

CREATE INDEX "IX_Codes_SearchVector" ON "Codes" USING GIN ("SearchVector");

CREATE TRIGGER icd10code_search_vector_update BEFORE INSERT OR UPDATE
              ON "Codes" FOR EACH ROW EXECUTE PROCEDURE
              tsvector_update_trigger("SearchVector", 'pg_catalog.english', "DiagnosisCode", "FullDescription");

CREATE TRIGGER icd9code_search_vector_update BEFORE INSERT OR UPDATE
              ON "ICD9Codes" FOR EACH ROW EXECUTE PROCEDURE
              tsvector_update_trigger("SearchVector", 'pg_catalog.english', "LongDescription", "ShortDescription", "Code");

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20180828111325_CodesSearchVectors', '2.1.1-rtm-30846');


