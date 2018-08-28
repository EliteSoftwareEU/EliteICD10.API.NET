using System;
using System.Linq;
using ICD10.API.Filters;
using ICD10.API.Models.Response;
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
            var responseModel = ICD9TOICD10MappingResponseModel.BuildResponseItems(model.ToList<dynamic>());
            return Ok(responseModel);
        }

        [HttpGet("{icd10code}/to-icd9")]
        public IActionResult ToIcd9(string icd10code)
        {
            var model = _service.MapToICD9(icd10code);
            var responseModel = ICD10TOICD9MappingResponseModel.BuildResponseItems(model.ToList<dynamic>());
            return Ok(responseModel);
        }


    }
}
