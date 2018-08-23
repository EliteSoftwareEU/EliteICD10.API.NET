using CsvHelper;
using ICD10.API.Models;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ICD10.API.Data.Seeds
{
    public static class ICD10CategorySeed
    {
        public static void ReadCsvIntoDatabase(IHostingEnvironment appEnvironment,
                                               ICD10DbContext dbContext)
        {
            if (dbContext.Categories.Any()) return;
            var rootDirectory = appEnvironment.ContentRootPath;
            var csvFile = File.OpenRead(Path.Join(rootDirectory, "Data/CSV/categories.csv"));
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
                    var category = new ICD10Category();
                    category.Code = (string)record["Field1"];
                    category.Title = (string)record["Field2"];
                    dbContext.Categories.Add(category);
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
            csv.Configuration.BadDataFound = null;
            csv.Configuration.HasHeaderRecord = false;
            csv.Configuration.BadDataFound = context =>
            {
                Console.WriteLine($"Bad data found on row '{context.RawRow}'");
            };
        }
    }
}
