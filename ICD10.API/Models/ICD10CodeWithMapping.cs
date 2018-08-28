using System;
namespace ICD10.API.Models
{
    public class ICD10CodeWithMapping : ICDBaseModel
    {
        public Guid ICD10CodeId { get; set; }
        public Guid ICD9TOICD10MappingId { get; set; }

        public ICD10Code ICD10Code { get; set; }
        public ICD9TOICD10Mapping ICD9TOICD10Mapping { get; set; }
    }
}
