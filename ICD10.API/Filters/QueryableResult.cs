using System;
using System.Collections.Generic;
using ICD10.API.Controllers;
using ICD10.API.Lib.Pagination;
using ICD10.API.Models;
using ICD10.API.Models.Response;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using ICD10.API.Lib;

namespace ICD10.API.Filters
{
    public class QueryableResult : ActionFilterAttribute
    {
        Type _outputModel;

        public QueryableResult(string outputModel) 
        {
            _outputModel = new ModelTypeResolver(outputModel).Resolve();
        }

        public override void OnResultExecuting(ResultExecutingContext context)
        {
            var query = (ObjectResult)context.Result;
            if (query == null) throw new Exception("Unable to retreive value of IQueryable from context result.");

            var apiController = context.Controller as ApiBaseController;

            if (apiController == null)
            {
                throw new InvalidOperationException("It is not an Api Controller!!!");
            }
            dynamic pagedList = query.Value;

            var outputItems = (List<dynamic>) _outputModel.GetMethod("BuildResponseItems")
                                                          .Invoke(null, 
                                                                  new object[] { pagedList.List });
            
            dynamic outputData = ApiOutputModel.Build(pagedList, apiController.Url, outputItems);

            context.HttpContext.Response.Headers.Add("X-Pagination", pagedList.GetHeader().ToJson());
            context.Result = new JsonResult(outputData);
        }
    }
}
