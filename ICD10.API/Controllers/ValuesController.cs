using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ICD10.API.Data;
using ICD10.API.Models.Response;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ICD10.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : Controller
    {
        private readonly ICD10DbContext _context;

        public ValuesController(ICD10DbContext context)
        {
            _context = context;
        }
        // GET api/values
        [HttpGet]
        public IActionResult Get()
        {
            var data = _context.Codes.Include(c => c.Category)
                               .Skip(100)
                               .Take(700)
                               .ToList();
            var items = new List<ICD10ResponseCodeModel>();
            foreach(var item in data)
            {
                var responseItem = new ICD10ResponseCodeModel();
                responseItem.AbbreviatedDescription = item.AbbreviatedDescription;
                responseItem.CategoryCode = item.Category.Code;
                responseItem.CategoryTitle = item.Category.Title;
                responseItem.DiagnosisCode = item.DiagnosisCode;
                responseItem.FullCode = item.FullCode;
                responseItem.FullDescription = item.FullDescription;
                items.Add(responseItem);
            }
            return Json(items);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
