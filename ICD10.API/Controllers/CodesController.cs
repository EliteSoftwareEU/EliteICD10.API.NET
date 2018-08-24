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
using Microsoft.EntityFrameworkCore;

namespace ICD10.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CodesController : ApiBaseController
    {
        private readonly ICodeService _service;

        public CodesController(IUrlHelper urlHelper, ICodeService service) : base(urlHelper)
        {
            _urlHelper = urlHelper;
            _service = service;
        }

        [Route("by-letter/{letter}")]
        [HttpGet]
        public IActionResult ByLetter(string letter)
        {
         
            return Json("ok");
        }

        [HttpGet]
        public IActionResult Index(PagingParams pagingParams)
        {
            var model = _service.GetCodes(pagingParams);

            Response.Headers.Add("X-Pagination", model.GetHeader().ToJson());

            var outputModel = new ApiOutputModel
            {
                Paging = model.GetHeader(),
                Links = GetLinks(model),
                Items =new List<dynamic> { null}
            };
            return Ok(outputModel);
        }

        private List<LinkInfo> GetLinks(PagedList<ICD10Code> list)
        {
            var links = new List<LinkInfo>();

            if (list.HasPreviousPage)
                links.Add(CreateLink("GetCodes", list.PreviousPageNumber,
                           list.PageSize, "previousPage", "GET"));

            links.Add(CreateLink("GetCodes", list.PageNumber,
                           list.PageSize, "self", "GET"));

            if (list.HasNextPage)
                links.Add(CreateLink("GetCodes", list.NextPageNumber,
                           list.PageSize, "nextPage", "GET"));

            return links;
        }

        private LinkInfo CreateLink(string routeName, int pageNumber, int pageSize,
                                    string rel, string method)
        {
            return new LinkInfo
            {
                Href = _urlHelper.Link(routeName,
                            new { PageNumber = pageNumber, PageSize = pageSize }),
                Rel = rel,
                Method = method
            };
        }
    }

}