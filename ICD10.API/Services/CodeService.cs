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

        public PagedList<ICD10Code> GetCodes(PagingParams pagingParams)
        {
            var query = _codes.AsQueryable();
            return new PagedList<ICD10Code>(query, pagingParams.PageNumber, pagingParams.PageSize);
        }

    }
}
