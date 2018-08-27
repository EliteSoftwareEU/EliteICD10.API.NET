using System;
using ICD10.API.Lib.Pagination;
using ICD10.API.Models;

namespace ICD10.API.Services
{
    public interface IICD9CodeService
    {
        PagedList GetCodes(ApiParams pagingParams);
        ICD9Code GetCode(string diagnosisCode);
    }
}
