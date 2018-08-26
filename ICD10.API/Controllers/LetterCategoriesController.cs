using System;
using ICD10.API.Filters;
using ICD10.API.Lib.Pagination;
using ICD10.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace ICD10.API.Controllers
{
    public class LetterCategoriesController : ApiBaseController
    {
        readonly ICategoryService _service;

        public LetterCategoriesController(ICategoryService service) : base()
        {
            _service = service;
        }


        [QueryableResult("ICD10ResponseCategoryModel")]
        [HttpGet]
        public IActionResult Get(string firstLetter, 
                                [FromQuery] ApiParams apiParams)
        {
            var model = _service.GetCategories(firstLetter, apiParams);
            return Ok(model);
        }


    }
}
