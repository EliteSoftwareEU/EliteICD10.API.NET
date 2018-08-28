using System;
using System.Collections.Generic;

namespace ICD10.API.Models
{
    public class ICD9TOICD10Mapping : ICDBaseModel
    {
        public string ICD9Code { get; set; }
        public string ICD10Code { get; set; }
        public string Flags { get; set; }

        public ICollection<ICD10CodeWithMapping> ICD10CodeWithMappings { get; set; }
    }
}
