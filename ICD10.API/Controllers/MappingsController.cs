using System;
using ICD10.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace ICD10.API.Controllers
{
    [Route("api/v1/[controller]")]
    public class MappingsController : ApiBaseController
    {
        readonly IICDMappingService _service;

        public MappingsController(IICDMappingService service) : base()
        {
            _service = service;
        }

        [HttpGet("{icd9code}/to-icd10")]
        public IActionResult ToIcd10(string icd9code)
        {
            var model = _service.MapToICD10(icd9code);
            return Ok(model);
        }

        [HttpGet("{icd10code}/to-icd9")]
        public IActionResult ToIcd9(string icd10code)
        {
            var model = _service.MapToICD10(icd10code);
            return Ok(model);
        }


    }
}
