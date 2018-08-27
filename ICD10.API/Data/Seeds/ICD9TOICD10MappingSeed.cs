using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using CsvHelper;
using CsvHelper.Configuration;
using ICD10.API.Models;
using Microsoft.AspNetCore.Hosting;

namespace ICD10.API.Data.Seeds
{
    public static class ICD9TOICD10MappingSeed
    {
        public static void ReadCsvIntoDatabase(IHostingEnvironment appEnvironment,
                                             ICD10DbContext dbContext)
        {
            if (dbContext.ICD9TOICD10Mappings.Any()) return;
            var rootDirectory = appEnvironment.ContentRootPath;
            var csvFile = File.OpenRead(Path.Join(rootDirectory, "Data/CSV/icd9toicd10cmgem.csv"));
            TextReader textReader = new StreamReader(csvFile);
            var csv = new CsvReader(textReader);
            ConfigureCSVReader(csv);
            try
            {
                var records = csv.GetRecords<dynamic>().ToList();

                foreach (var r in records)
                {
                    if ((records.IndexOf(r)) == 0) continue;
                    var record = new Dictionary<string, object>(r);
                    var code = new ICD9TOICD10Mapping();
                    string dxCode = record["icd9cm"] as string;

                    code.ICD9Code = dxCode;
                    code.ICD10Code = record["icd10cm"] as string;
                    code.Flags = record["flags"] as string;
                    dbContext.ICD9TOICD10Mappings.Add(code);
                }
                dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void ConfigureCSVReader(CsvReader csv)
        {
            csv.Configuration.TrimOptions = TrimOptions.Trim;
            csv.Configuration.Encoding = Encoding.UTF8;
            csv.Configuration.HasHeaderRecord = true;
            csv.Configuration.BadDataFound = context =>
            {
                Console.WriteLine($"Bad data found on row '{context.RawRow}'");
            };
        }
    }
}
