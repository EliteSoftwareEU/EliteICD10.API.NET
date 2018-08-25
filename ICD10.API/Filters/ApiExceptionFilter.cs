using System;
using System.Collections.Generic;
using System.Net;
using ICD10.API.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.Internal;

namespace Expenses.NET.Filters
{
    public class ApiExceptionFilter : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            if (context.Exception is NotFoundException)
            {
                // handle explicit 'known' API errors
                var ex = context.Exception as NotFoundException;
                context.Exception = null;

                context.Result = new JsonResult(new { error = new List<string>() { ex.Message } });
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.NotFound;
            }
            else if (context.Exception is BadRequestException)
            {
                var ex = context.Exception as BadRequestException;
                context.Exception = null;

                context.Result = new JsonResult(new { error = new List<string>() { ex.Message } });
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            }
            else if (context.Exception is UnauthorizedAccessException)
            {
                context.Result = new JsonResult(new { error = new List<string>() { context.Exception.Message } });
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
            }
            else if (context.Exception is ForbiddenException)
            {
                context.Result = new JsonResult(new { error = new List<string>() { context.Exception.Message } });
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.Forbidden;
            }
            else if (context.Exception is AmbiguousActionException)
            {
                context.Result = new JsonResult(new { error = new List<string>() { context.Exception.Message } });
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            }

            base.OnException(context);
        }
    }
}
