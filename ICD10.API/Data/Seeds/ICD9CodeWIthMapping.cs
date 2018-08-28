using System;
using System.Linq;
using ICD10.API.Models;
using Microsoft.EntityFrameworkCore;

namespace ICD10.API.Data.Seeds
{
    public static class ICD9CodeWIthMappingSeed
    {
        public static void Run(ICD10DbContext dbContext)
        {
            if (dbContext.ICD9CodeWithMappings.Any()) return;
            var icd9Codes = dbContext.ICD9Codes.ToList();
            foreach (var mapping in dbContext.ICD10TOICD9Mappings)
            {
                var icd9code = icd9Codes.Where(c => c.Code == mapping.ICD9Code)
                                          .FirstOrDefault();

                if (icd9code == null) continue;
                var codeWithMapping = new ICD9CodeWithMapping();
                codeWithMapping.ICD10TOICD9Mapping = mapping;
                codeWithMapping.ICD9Code = icd9code;
                dbContext.ICD9CodeWithMappings.Add(codeWithMapping);
            }
            dbContext.SaveChanges();
        }
    }
}
