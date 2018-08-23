using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ICD10.API.Data;
using ICD10.API.Models.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ICD10.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CodesController : ApiBaseController
    {
        public CodesController(ICD10DbContext context) : base(context)
        {
            _dbContext = context;
        }

        [Route("by-letter/{letter}")]
        [HttpGet]
        public IActionResult ByLetter(string letter)
        {
            var codes = _dbContext.Codes
                                  .Include(c => c.Category)
                                  .Where(c => c.Category.Code.StartsWith(letter))
                                  .ToList();
            List<ICD10ResponseCodeModel> items = GetResponseItems(codes);
            return Json(items);
        }

    }
}