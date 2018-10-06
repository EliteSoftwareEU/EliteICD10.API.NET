using System;
using System.Collections.Generic;
using System.Linq;
using ICD10.API.Data;
using ICD10.API.Lib.Pagination;
using ICD10.API.Models;

namespace ICD10.API.Services
{
    public class ICD9CodeService : IICD9CodeService
    {
        readonly IQueryable<ICD9Code> _codes;
        readonly ICD10DbContext _context;

        public ICD9CodeService(ICD10DbContext context) 
        {
            _context = context;
            _codes = _context.ICD9Codes;    
        }

        public ICD9Code GetCode(string diagnosisCode)
        {
            return _codes.FirstOrDefault(c => c.Code == diagnosisCode);
        }

        public PagedList GetCodes(ApiParams apiParams)
        {
            var query = _codes.AsQueryable();
            return FilterAndReturnPagedList(apiParams, ref query);
        }

        static PagedList FilterAndReturnPagedList(ApiParams apiParams,
                                                          ref IQueryable<ICD9Code> query)
        {
            var filterBy = apiParams.FilterBy.Trim().ToLowerInvariant();
            if (!string.IsNullOrEmpty(filterBy))
            {
                query = query
                    .Where(m => m.LongDescription.ToLowerInvariant().Contains(filterBy)
                           || m.ShortDescription.ToLowerInvariant().Contains(filterBy)
                           || m.Code.ToLowerInvariant().Contains(filterBy));
            }
            return new PagedList(query, apiParams.PageNumber, apiParams.PageSize);
        }
    }
}
