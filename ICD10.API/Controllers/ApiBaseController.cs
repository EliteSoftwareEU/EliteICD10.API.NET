using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ICD10.API.Data;
using ICD10.API.Lib.Pagination;
using ICD10.API.Models;
using ICD10.API.Models.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ICD10.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiBaseController : Controller
    {
        protected IUrlHelper _urlHelper;

        public ApiBaseController(IUrlHelper urlHelper)
        {
            _urlHelper = urlHelper;
        }      

        protected static List<ICD10ResponseCodeModel> GetResponseItems(List<ICD10Code> codes)
        {
            var items = new List<ICD10ResponseCodeModel>();
            foreach (var item in codes)
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
            return items;
        }

        protected List<LinkInfo> GetLinks<T>(PagedList<T> list, string methodName)
        {
            var links = new List<LinkInfo>();

            if (list.HasPreviousPage)
                links.Add(CreateLink(methodName, list.PreviousPageNumber, list.PageSize, "previousPage", "GET"));

            links.Add(CreateLink(methodName, list.PageNumber, list.PageSize, "self", "GET"));

            if (list.HasNextPage)
                links.Add(CreateLink(methodName, list.NextPageNumber,list.PageSize, "nextPage", "GET"));

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