using System;
using System.Collections.Generic;
using ICD10.API.Lib.Pagination;
using Microsoft.AspNetCore.Mvc;

namespace ICD10.API.Lib
{
    public class LinkBuilder
    {
        readonly IUrlHelper _urlHelper;

        public LinkBuilder(IUrlHelper urlHelper)
        {
            _urlHelper = urlHelper;
        }

        public List<LinkInfo> BuildLinks(PagedList list)
        {
            var links = new List<LinkInfo>();

            if (list.HasPreviousPage)
                links.Add(CreateLink("default", list.PreviousPageNumber, list.PageSize, "previousPage", "GET"));

            links.Add(CreateLink("default", list.PageNumber, list.PageSize, "self", "GET"));

            if (list.HasNextPage)
                links.Add(CreateLink("default", list.NextPageNumber, list.PageSize, "nextPage", "GET"));

            return links;
        }


        private LinkInfo CreateLink(string routeName, int pageNumber, int pageSize,
                                    string rel, string method)
        {
            return new LinkInfo
            {
                Href = _urlHelper.Link("default",
                    new
                    {
                        PageNumer = pageNumber,
                        PageSize = pageSize
                    }),
                Rel = rel,
                Method = method
            };
        }
    }
}
