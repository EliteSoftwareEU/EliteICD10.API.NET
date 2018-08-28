using System;
using System.Collections.Generic;
using ICD10.API.Lib;

namespace ICD10.API.Models.Response
{
    public class ICD9TOICD10MappingResponseModel : BaseResponseModel
    {
        public string ICD9Code { get; set; }
        public string ICD10Code { get; set; }
        public Dictionary<string, string> Flags { get; set; }
        public List<ICD10ResponseCodeModel> MappingDetails { get; set; }
        
        public static new List<dynamic> BuildResponseItems(List<dynamic> items)
        {
            var respItems = new List<dynamic>();
            foreach (var item in items)
            {
                ICD9TOICD10MappingResponseModel responseItem = BuildResponseItem(item);
                respItems.Add(responseItem);
            }

            return respItems;
        }

        public static ICD9TOICD10MappingResponseModel BuildResponseItem(dynamic item)
        {
            var responseItem = new ICD9TOICD10MappingResponseModel();
            responseItem.ICD9Code = item.ICD9Code;
            responseItem.ICD10Code = item.ICD10Code;
            responseItem.MappingDetails = new List<ICD10ResponseCodeModel>();
            responseItem.Flags = new MappingFlagsResolver(item.Flags).Resolve();
            foreach(var mappedItem in item.ICD10CodeWithMappings)
            {
                var icd10CodeResponse = ICD10ResponseCodeModel.BuildResponseItem(mappedItem.ICD10Code);
                responseItem.MappingDetails.Add(icd10CodeResponse);
            }
            return responseItem;
        } 
    }
}
