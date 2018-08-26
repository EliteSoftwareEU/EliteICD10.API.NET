using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Expenses.NET.Filters;
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
    [ApiExceptionFilter]
    public abstract class ApiBaseController : ControllerBase
    {
    }
}