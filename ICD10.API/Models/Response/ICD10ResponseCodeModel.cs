using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ICD10.API.Models.Response
{
    public class ICD10ResponseCodeModel
    {
        public string CategoryCode { get; set; }
        public string DiagnosisCode { get; set; }
        public string FullCode { get; set; }
        public string AbbreviatedDescription { get; set; }
        public string FullDescription { get; set; }
        public string CategoryTitle { get; set; }        
    }
}
