using Expenses.NET.Filters;
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