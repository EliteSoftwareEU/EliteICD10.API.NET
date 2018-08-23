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

        public ICD10DbContext(DbContextOptions<ICD10DbContext> options) : base(options)
        {
        }
    }
}
