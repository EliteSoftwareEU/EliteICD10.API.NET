using ICD10.API.Data;
using ICD10.API.Lib.Pagination;
using ICD10.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ICD10.API.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly List<ICD10Category> _categories;
        private readonly ICD10DbContext _context;

        public CategoryService(ICD10DbContext context)
        {
            _context = context;
            _categories = _context.Categories.ToList();
        }

        public PagedList<ICD10Category> GetCategories(PagingParams pagingParams)
        {
            var query = _categories.AsQueryable();
            return new PagedList<ICD10Category>(query, pagingParams.PageNumber, pagingParams.PageSize);
        }

        public PagedList<ICD10Category> GetCategoriesByLetter(string letter, PagingParams pagingParams)
        {
            var query = _categories.Where(c => c.Code.ToLower().StartsWith(letter.ToLower()))
                                   .AsQueryable();
            return new PagedList<ICD10Category>(query, pagingParams.PageNumber, pagingParams.PageSize);
        }
    }
}
