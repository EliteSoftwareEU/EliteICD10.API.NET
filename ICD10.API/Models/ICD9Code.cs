using System;
using NpgsqlTypes;

namespace ICD10.API.Models
{
    public class ICD9Code : ICDBaseModel
    {
        public string Code { get; set; }
        public string LongDescription { get; set; }
        public string ShortDescription { get; set; }
        public int Version { get; set;  }
        public NpgsqlTsVector SearchVector { get; set; }
    }
}