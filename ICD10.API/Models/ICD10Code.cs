using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ICD10.API.Models
{
    public class ICD10Code : ICDBaseModel
    {
        public Guid ICD10CategoryId { get; set; }
        public string DiagnosisCode { get; set; }
        public string FullCode
        {
            get
            {
                return Category.Code + DiagnosisCode;
            }
        }
        public string AbbreviatedDescription { get; set; }
        public string FullDescription { get; set; }
        public string CategoryTitle
        {
            get
            {
               return Category.Title;
            } 
        }

        public ICD10Category Category { get; set; }
    }
}
