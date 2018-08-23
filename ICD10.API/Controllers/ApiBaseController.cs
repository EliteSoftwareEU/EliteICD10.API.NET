using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ICD10.API.Data;
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
        protected ICD10DbContext _dbContext;

        public ApiBaseController(ICD10DbContext context)
        {
            _dbContext = context;
        }

        protected static List<ICD10ResponseCategoryModel> GetResponseItems(List<ICD10Category> categories)
        {
            var items = new List<ICD10ResponseCategoryModel>();
            foreach (var item in categories)
            {
                var responseItem = new ICD10ResponseCategoryModel();
                responseItem.Code = item.Code;
                responseItem.Title = item.Title;
                items.Add(responseItem);
            }

            return items;
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
    }
}