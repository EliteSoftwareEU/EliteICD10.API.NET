using System;
using ICD10.API.Exceptions;
using ICD10.API.Filters;
using ICD10.API.Lib.Pagination;
using ICD10.API.Models.Response;
using ICD10.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace ICD10.API.Controllers
{
    [Route("api/v1/[controller]")]
    public class ICD9CodesController : ApiBaseController
    {
        readonly IICD9CodeService _service;

        public ICD9CodesController(IICD9CodeService service) : base()
        {
            _service = service;
        }

        [HttpGet]
        [QueryableResult("ICD9ResponseCodeModel")]
        public IActionResult Get([FromQuery] ApiParams apiParams)
        {
            var model = _service.GetCodes(apiParams);
            return Ok(model);
        }

        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            var model = _service.GetCode(id);
            if (model == null) throw new NotFoundException("ICD9 Code does not exists");
            else
            {
                var responseModel = ICD9ResponseCodeModel.BuildResponseItem(model);
                return Ok(new { ICD9Code = responseModel });
            }
        }

    }
}
