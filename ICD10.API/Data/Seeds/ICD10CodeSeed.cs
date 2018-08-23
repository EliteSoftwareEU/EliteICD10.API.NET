using CsvHelper;
using CsvHelper.Configuration;
using ICD10.API.Models;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICD10.API.Data.Seeds
{
    public static class ICD10CodeSeed
    {
        public static void ReadCsvIntoDatabase(IHostingEnvironment appEnvironment,
                                               ICD10DbContext dbContext)
        {
            if (dbContext.Codes.Any()) return;
            var rootDirectory = appEnvironment.ContentRootPath;
            var csvFile = File.OpenRead(Path.Join(rootDirectory, "Data/CSV/codes.csv"));
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
                    var code = new ICD10Code();
                    string categoryCode = (string)record["Category Code"];


                    var dbCategory = dbContext.Categories.FirstOrDefault(c => c.Code.Equals(categoryCode));
                    code.Category = dbCategory;
                    code.DiagnosisCode = (string)record["Diagnosis Code"];
                    code.AbbreviatedDescription = (string)record["Abbreviated Description"];
                    code.FullDescription = (string)record["Full Description"];
                    dbContext.Codes.Add(code);
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
