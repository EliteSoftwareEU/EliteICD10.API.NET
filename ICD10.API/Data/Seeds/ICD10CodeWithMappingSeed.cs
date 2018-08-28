using System;
using System.Linq;
using ICD10.API.Models;
using Microsoft.EntityFrameworkCore;

namespace ICD10.API.Data.Seeds
{
    public static class ICD10CodeWithMappingSeed
    {
        public static void Run(ICD10DbContext dbContext)
        {
            if (dbContext.ICD10CodeWithMappings.Any()) return;
            var icd10Codes = dbContext.Codes.Include(c => c.Category).ToList();
            foreach(var mapping in dbContext.ICD9TOICD10Mappings) 
            {
                var icd10code = icd10Codes.Where(c => c.FullCode == mapping.ICD10Code)
                                          .FirstOrDefault();
                
                if (icd10code == null) continue;
                var codeWithMapping = new ICD10CodeWithMapping();
                codeWithMapping.ICD9TOICD10Mapping = mapping;
                codeWithMapping.ICD10Code = icd10code;
                dbContext.ICD10CodeWithMappings.Add(codeWithMapping);
            }
            dbContext.SaveChanges();
        }
    }
}
