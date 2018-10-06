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
        /// <summary>
        /// Gets all categories, can be filtered/search with filterBy param
        /// </summary>
        [HttpGet]
        [QueryableResult("ICD10ResponseCategoryModel")]
        public IActionResult Get([FromQuery] ApiParams apiParams)
        {
            var model = _service.GetCategories(apiParams);
            return  Ok(model);
        }

        /// <summary>
        /// Gets a specific category by category code, where id is the category code
        /// </summary>
        /// <param name="id"></param>  
        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            var model = _service.GetCategory(id);
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