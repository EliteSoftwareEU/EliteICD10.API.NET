using ICD10.API.Data;
using ICD10.API.Lib.Pagination;
using ICD10.API.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ICD10.API.Services
{
    public class CodeService : ICodeService
    {
        private readonly List<ICD10Code> _codes;
        private readonly ICD10DbContext _context;

        public CodeService(ICD10DbContext context)
        {
            _context = context;
            _codes = _context.Codes.Include(c => c.Category).ToList();
        }

        public PagedList GetCodes(ApiParams apiParams)
        {
            var query = _codes.AsQueryable();
            return FilterAndReturnPagedList(apiParams, ref query);
        }

        public PagedList GetCodes(string firstLetter, ApiParams apiParams)
        {
            var query = _codes.Where(c => c.Category.Code.ToLowerInvariant().StartsWith(firstLetter.ToLowerInvariant()))                                                               
                              .AsQueryable();
            return FilterAndReturnPagedList(apiParams, ref query);
        }

        public PagedList GetCodesFromCategory(string categoryCode, ApiParams apiParams)
        {
            var query = _codes.Where(c => c.Category.Code == categoryCode)
                              .AsQueryable();
            return FilterAndReturnPagedList(apiParams, ref query);
        }

        private static PagedList FilterAndReturnPagedList(ApiParams apiParams, 
                                                          ref IQueryable<ICD10Code> query)
        {
            var filterBy = apiParams.FilterBy.Trim().ToLowerInvariant();
            if (!string.IsNullOrEmpty(filterBy))
            {
                query = query
                    .Where(m => m.AbbreviatedDescription.ToLowerInvariant().Contains(filterBy)
                           || m.FullDescription.ToLowerInvariant().Contains(filterBy)
                           || m.FullCode.ToLowerInvariant().Contains(filterBy));
            }
            return new PagedList(query, apiParams.PageNumber, apiParams.PageSize);
        }

        public ICD10Code GetCode(string diagnosisCode)
        {
            return _codes.FirstOrDefault(c => c.FullCode == diagnosisCode);
        }
    }
}
