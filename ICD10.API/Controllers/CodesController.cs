using ICD10.API.Exceptions;
using ICD10.API.Filters;
using ICD10.API.Lib.Pagination;
using ICD10.API.Models.Response;
using ICD10.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace ICD10.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CodesController : ApiBaseController
    {
        readonly ICodeService _service;

        public CodesController(ICodeService service) : base()
        {
            _service = service;
        }

        [HttpGet(Name = "GetCodes")]
        [Route("find")]
        [QueryableResult("ICD10ResponseCodeModel")]
        public IActionResult Index([FromQuery] ApiParams apiParams)
        {
            var model = _service.GetCodes(apiParams);
            return Ok(model);
        }

        [HttpGet(Name = "GetCodesByLetter")]
        [Route("by-letter/{firstLetter}")]
        [QueryableResult("ICD10ResponseCodeModel")]
        public IActionResult ByLetter(string firstLetter,
                                      [FromQuery] ApiParams apiParams)
        {
            var model = _service.GetCodes(firstLetter, apiParams);
            return Ok(model);
        }

        [HttpGet(Name = "GetCodesFromCategory")]
        [Route("from-category/{categoryCode}")]
        [QueryableResult("ICD10ResponseCodeModel")]
        public IActionResult FromCategoryCode(string categoryCode,
                                              [FromQuery] ApiParams apiParams)
        {
            var model = _service.GetCodesFromCategory(categoryCode, apiParams);
            return Ok(model);
        }

        [HttpGet(Name = "GetCodeDetails")]
        [Route("show/{diagnosisCode}")]
        public IActionResult Show(string diagnosisCode)
        {
            var model = _service.GetCode(diagnosisCode);
            if (model == null) throw new NotFoundException("ICD10 Code does not exists");
            else
            {
                var responseModel = ICD10ResponseCodeModel.BuildResponseItem(model);
                return Ok(new { ICD10Code = responseModel });
            }
        }
    }
}