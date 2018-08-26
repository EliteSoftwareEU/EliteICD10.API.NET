using System;
using ICD10.API.Filters;
using ICD10.API.Lib.Pagination;
using ICD10.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace ICD10.API.Controllers
{
    public class LettersCodesController : ApiBaseController
    {
        readonly ICodeService _service;

        public LettersCodesController(ICodeService service) : base()
        {
            _service = service;
        }

        [HttpGet]
        [QueryableResult("ICD10ResponseCodeModel")]
        public IActionResult Get(string firstLetter,
                                 [FromQuery] ApiParams apiParams)
        {
            var model = _service.GetCodes(firstLetter, apiParams);
            return Ok(model);
        }
    }
    
}
