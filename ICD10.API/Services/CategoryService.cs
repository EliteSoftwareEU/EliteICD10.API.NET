using ICD10.API.Data;
using ICD10.API.Lib.Pagination;
using ICD10.API.Models;
using ICD10.API.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
namespace ICD10.API.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly List<ICD10Category> _categories;
        private readonly ICD10DbContext _context;

        public CategoryService(ICD10DbContext context)
        {
            _context = context;
            _categories = _context.Categories.Include(c => c.ICD10Codes).ToList();
        }

        public PagedList GetCategories(ApiParams apiParams)
        {
            var query = _categories.AsQueryable();
            return FilterAndReturnPagedList(apiParams, ref query);
        }

        public PagedList GetCategories(string firstLetter, ApiParams apiParams)
        {
            var query = _categories.Where(c => c.Code.ToLower().StartsWith(firstLetter.ToLower()))
                                   .AsQueryable();
            return FilterAndReturnPagedList(apiParams, ref query);
        }

        public ICD10Category GetCategory(string categoryCode)
        {
            var category = _context.Categories
                            .Where(c => c.Code.ToLowerInvariant() == categoryCode.ToLowerInvariant())
                            .Include(c => c.ICD10Codes)
                            .FirstOrDefault();
            
            return category;                         
        }

        private static PagedList FilterAndReturnPagedList(ApiParams apiParams, ref IQueryable<ICD10Category> query)
        {
            var filterBy = apiParams.FilterBy.Trim().ToLowerInvariant();
            if (!string.IsNullOrEmpty(filterBy))
            {
                query = query
                       .Where(m => m.Title.ToLowerInvariant().Contains(filterBy)
                       || m.Code.ToLowerInvariant().Contains(filterBy));
            }

            return new PagedList(query, apiParams.PageNumber, apiParams.PageSize);
        }
    }
}
