using System;
using System.Collections.Generic;

namespace ICD10.API.Models
{
    public class ICD10TOICD9Mapping : ICDBaseModel
    {
        public string ICD9Code { get; set; }
        public string ICD10Code { get; set; }
        public string Flags { get; set; }

        public List<ICD9CodeWithMapping> ICD9CodeWithMappings { get; set; }
    }
}