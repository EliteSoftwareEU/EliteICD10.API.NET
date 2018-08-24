using ICD10.API.Lib.Pagination;
using ICD10.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ICD10.API.Services
{
    public interface ICategoryService
    {
        PagedList<ICD10Category> GetCategories(PagingParams pagingParams);
        PagedList<ICD10Category> GetCategoriesByLetter(string letter, PagingParams pagingParams);
    }
}
