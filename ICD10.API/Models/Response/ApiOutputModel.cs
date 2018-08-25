using ICD10.API.Lib;
using ICD10.API.Lib.Pagination;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ICD10.API.Models.Response
{
    public class ApiOutputModel
    {
        public PagingHeader Paging { get; set; }
        public List<LinkInfo> Links { get; set; }
        public List<dynamic> Items { get; set; }

        public static ApiOutputModel Build(PagedList model, 
                                           IUrlHelper helper,
                                           List<dynamic> items) 
        {
            return new ApiOutputModel
            {
                Paging = model.GetHeader(),
                Links = new LinkBuilder(helper).BuildLinks(model),
                Items = items
            };    
        }
    }
}
