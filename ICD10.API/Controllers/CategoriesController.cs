using ICD10.API.Exceptions;
using ICD10.API.Filters;
using ICD10.API.Lib.Pagination;
using ICD10.API.Models.Response;
using ICD10.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace ICD10.API.Controllers
{
    [Route("api/v1/[controller]")]
    public class CategoriesController : ApiBaseController
    {
        readonly ICategoryService _service;

        public CategoriesController(ICategoryService service) : base()
        {
            _service = service;
        }

        [HttpGet(Name = "GetCategories")]
        [Route("find")]
        [QueryableResult("ICD10ResponseCategoryModel")]
        public IActionResult Index([FromQuery] ApiParams apiParams)
        {
            var model = _service.GetCategories(apiParams);
            return Ok(model);
        }

        [Route("by-letter/{firstLetter}")]
        [HttpGet(Name = "GetCategoriesByLetter")]
        [QueryableResult("ICD10ResponseCategoryModel")]
        public IActionResult ByLetter(string firstLetter, [FromQuery] ApiParams apiParams)
        {
            var model = _service.GetCategories(firstLetter, apiParams);
            return Ok(model);
        }

        [Route("show/{categoryCode}")]
        public IActionResult Show(string categoryCode)
        {
            var model = _service.GetCategory(categoryCode);

            if (model == null)
            {
                throw new NotFoundException("Category does not exists");
            }
            else
            {
                var responseModel = ICD10ResponseCategoryModel.BuildResponseItem(model);
                return Ok(new { ICD10Category = responseModel });
            }
        }
    }
}