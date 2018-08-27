using ICD10.API.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ICD10.API.Data
{
    public class ICD10DbContext : DbContext
    {
        public DbSet<ICD10Category> Categories { get; set; }
        public DbSet<ICD10Code> Codes { get; set; }
        public DbSet<ICD9Code> ICD9Codes { get; set; }
        public DbSet<ICD9TOICD10Mapping> ICD9TOICD10Mappings { get; set; }
        public DbSet<ICD10TOICD9Mapping> ICD10TOICD9Mappings { get; set; }

        public ICD10DbContext(DbContextOptions<ICD10DbContext> options) : base(options)
        {
        }
    }
}
