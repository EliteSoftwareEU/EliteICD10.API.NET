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
    public static class ICD9CodeSeed
    {
        public static void ReadCsvIntoDatabase(IHostingEnvironment appEnvironment,
                                              ICD10DbContext dbContext)
        {
            if (dbContext.ICD9Codes.Any()) return;
            var rootDirectory = appEnvironment.ContentRootPath;
            var csvFile = File.OpenRead(Path.Join(rootDirectory, "Data/CSV/icd9dx2015.csv"));
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
                    var code = new ICD9Code();
                    string dxCode = record["dgns_cd"] as string;

                    code.Code = dxCode;
                    code.LongDescription = record["longdesc"] as string;
                    code.ShortDescription = record["shortdesc"] as string;
                    code.Version = Int32.Parse(record["version"] as string);
                    dbContext.ICD9Codes.Add(code);
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
