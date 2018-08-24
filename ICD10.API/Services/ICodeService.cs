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
        PagedList<ICD10Code> GetCodes(PagingParams pagingParams);
    }
}
