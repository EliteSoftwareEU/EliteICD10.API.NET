using System;
using System.Collections.Generic;
using ICD10.API.Models;

namespace ICD10.API.Services
{
    public interface IICDMappingService
    {
        List<ICD9TOICD10Mapping> MapToICD10(string icd9code);
        List<ICD10TOICD9Mapping> MapToICD9(string icd10code);
    }
}
