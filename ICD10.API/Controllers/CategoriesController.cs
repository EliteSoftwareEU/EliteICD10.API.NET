using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ICD10.API.Data;
using ICD10.API.Lib.Pagination;
using ICD10.API.Models;
using ICD10.API.Models.Response;
using ICD10.API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ICD10.API.Controllers
{
    [Route("api/v1/[controller]")]
    public class CategoriesController : ApiBaseController
    {
        private readonly ICategoryService _service;

        public CategoriesController(IUrlHelper urlHelper, ICategoryService service) : base(urlHelper)
        {
            _urlHelper = urlHelper;
            _service = service;
        }

        [Route("by-letter/{letter}")]
        [HttpGet]
        public IActionResult ByLetter(string letter, [FromQuery] PagingParams pagingParams)
        {
            var model = _service.GetCategoriesByLetter(letter, pagingParams);
            Response.Headers.Add("X-Pagination", model.GetHeader().ToJson());
            var outputModel = new ApiOutputModel
            {
                Paging = model.GetHeader(),
                Links = GetLinks(model, "ByLetter"),
                Items = GetCategoriesResponseItems(model.List.ToList<dynamic>())
            };
            return Ok(outputModel);
        }

        [HttpGet]
        public IActionResult Index([FromQuery] PagingParams pagingParams)
        {
            var model = _service.GetCategories(pagingParams);

            Response.Headers.Add("X-Pagination", model.GetHeader().ToJson());

            var outputModel = new ApiOutputModel
            {
                Paging = model.GetHeader(),
                Links = GetLinks(model, "Index"),
                Items = GetCategoriesResponseItems(model.List.ToList<dynamic>())
            };
            return Ok(outputModel);
        }

        private static List<dynamic> GetCategoriesResponseItems(List<dynamic> categories)
        {
            var items = new List<dynamic>();
            foreach (var item in categories)
            {
                var responseItem = new ICD10ResponseCategoryModel();
                responseItem.Code = item.Code;
                responseItem.Title = item.Title;
                items.Add(responseItem);
            }

            return items;
        }
    }
}