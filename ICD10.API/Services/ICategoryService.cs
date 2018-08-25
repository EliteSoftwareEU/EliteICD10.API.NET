using ICD10.API.Lib.Pagination;
using ICD10.API.Models;

namespace ICD10.API.Services
{
    public interface ICategoryService
    {
        PagedList GetCategories(ApiParams apiParams);
        PagedList GetCategories(string firstLetter, ApiParams apiParams);
        ICD10Category GetCategory(string categoryCode);
    }
}
