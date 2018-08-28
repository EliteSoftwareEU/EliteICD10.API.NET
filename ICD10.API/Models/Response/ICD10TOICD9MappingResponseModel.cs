using System;
using System.Collections.Generic;
using ICD10.API.Lib;

namespace ICD10.API.Models.Response
{
    public class ICD10TOICD9MappingResponseModel : BaseResponseModel
    {
        public string ICD9Code { get; set; }
        public string ICD10Code { get; set; }
        public Dictionary<string, string> Flags { get; set; }
        public List<ICD9ResponseCodeModel> MappingDetails { get; set; }

        public static new List<dynamic> BuildResponseItems(List<dynamic> items)
        {
            var respItems = new List<dynamic>();
            foreach (var item in items)
            {
                ICD10TOICD9MappingResponseModel responseItem = BuildResponseItem(item);
                respItems.Add(responseItem);
            }

            return respItems;
        }

        public static ICD10TOICD9MappingResponseModel BuildResponseItem(dynamic item)
        {
            var responseItem = new ICD10TOICD9MappingResponseModel();
            responseItem.ICD9Code = item.ICD9Code;
            responseItem.ICD10Code = item.ICD10Code;
            responseItem.MappingDetails = new List<ICD9ResponseCodeModel>();
            responseItem.Flags = new MappingFlagsResolver(item.Flags).Resolve();
            foreach(var mappedItem in item.ICD9CodeWithMappings)
            {
                var icd9Response = ICD9ResponseCodeModel.BuildResponseItem(mappedItem.ICD9Code);
                responseItem.MappingDetails.Add(icd9Response);
            }
            return responseItem;
        } 
    }
}
