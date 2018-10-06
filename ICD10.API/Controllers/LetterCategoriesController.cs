using System;
using ICD10.API.Filters;
using ICD10.API.Lib.Pagination;
using ICD10.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace ICD10.API.Controllers
{
    [Route("api/v1/letters")]
    public class LetterCategoriesController : ApiBaseController
    {
        readonly ICategoryService _service;

        public LetterCategoriesController(ICategoryService service) : base()
        {
            _service = service;
        }

        /// <summary>
        /// Gets all categories starting with a given first letter, 
        /// can be filtered/search with filterBy param
        /// </summary>
        [QueryableResult("ICD10ResponseCategoryModel")]
        [Route("{firstLetter}/categories")]
        [HttpGet]
        public IActionResult Get(string firstLetter, 
                                [FromQuery] ApiParams apiParams)
        {
            var model = _service.GetCategories(firstLetter, apiParams);
            return Ok(model);
        }
    }
}