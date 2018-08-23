using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ICD10.API.Data;
using ICD10.API.Models.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ICD10.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CategoriesController : ApiBaseController
    {
        public CategoriesController(ICD10DbContext context) : base(context)
        {
            _dbContext = context;
        }

        [Route("by-letter/{letter}")]
        [HttpGet]
        public IActionResult ByLetter(string letter)
        {
            var categories = _dbContext.Categories
                                       .Where(c => c.Code.StartsWith(letter))
                                       .ToList();
            List<ICD10ResponseCategoryModel> items = GetResponseItems(categories);
            return Json(items);
        }

    
    }
}