using ICD10.API.Data.Seeds;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ICD10.API.Data
{
    public static class DataInitializer
    {
        public static void Initialize(IHostingEnvironment environment, ICD10DbContext context)
        {
            ICD10CategorySeed.ReadCsvIntoDatabase(environment, context);
            ICD10CodeSeed.ReadCsvIntoDatabase(environment, context);
        }
    }
}