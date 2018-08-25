using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ICD10.API.Lib.Pagination
{
    public class ApiParams
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 30;
        public string FilterBy { get; set; } = "";
    }
}
