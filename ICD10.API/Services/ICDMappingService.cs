using System;
using System.Collections.Generic;
using System.Linq;
using ICD10.API.Data;
using ICD10.API.Models;
using Microsoft.EntityFrameworkCore;

namespace ICD10.API.Services
{
    public class ICDMappingService : IICDMappingService
    {
        private readonly List<ICD9TOICD10Mapping> _icd9ToIcd10codes;
        private readonly List<ICD10TOICD9Mapping> _icd10ToIcd9codes;
        private readonly ICD10DbContext _context;

        public ICDMappingService(ICD10DbContext context)
        {
            _context = context;
            _icd10ToIcd9codes = _context.ICD10TOICD9Mappings
                                        .Include(c => c.ICD9CodeWithMappings)
                                        .ThenInclude(m => m.ICD9Code)
                                        .ToList();
            
            _icd9ToIcd10codes = _context.ICD9TOICD10Mappings
                                        .Include(c => c.ICD10CodeWithMappings)
                                        .ThenInclude(m => m.ICD10Code)
                                        .ThenInclude(cw => cw.Category)
                                        .ToList();
        }

        public List<ICD9TOICD10Mapping> MapToICD10(string icd9code)
        {
            return _icd9ToIcd10codes.Where(c => c.ICD9Code.ToLowerInvariant() == icd9code.ToLowerInvariant())
                             .ToList();
        }

        public List<ICD10TOICD9Mapping> MapToICD9(string icd10code)
        {
            return _icd10ToIcd9codes.Where(c => c.ICD10Code.ToLowerInvariant() == icd10code.ToLowerInvariant())
                                    .ToList();
        }
    }
}
