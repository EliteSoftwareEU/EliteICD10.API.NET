using ICD10.API.Lib.Pagination;
using ICD10.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ICD10.API.Services
{
    public interface ICodeService
    {
        PagedList GetCodes(ApiParams pagingParams);
        PagedList GetCodes(string firstLetter, ApiParams apiParams);
        PagedList GetCodesFromCategory(string categoryCode, ApiParams apiParams);
        ICD10Code GetCode(string diagnosisCode);
    }
}