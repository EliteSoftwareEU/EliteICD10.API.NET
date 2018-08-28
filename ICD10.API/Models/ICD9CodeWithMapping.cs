using System;
namespace ICD10.API.Models
{
    public class ICD9CodeWithMapping : ICDBaseModel
    {
        public Guid ICD9CodeId { get; set; }
        public Guid ICD10TOICD9MappingId { get; set; }

        public ICD9Code ICD9Code { get; set; }
        public ICD10TOICD9Mapping ICD10TOICD9Mapping { get; set; }
    }
}
