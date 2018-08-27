using System;
using System.Collections.Generic;

namespace ICD10.API.Models.Response
{
    public class ICD9ResponseCodeModel : BaseResponseModel
    {
        public string Code { get; set; }
        public string LongDescription { get; set; }
        public string ShortDescription { get; set; }
        public int Version { get; set; }

        public static new List<dynamic> BuildResponseItems(List<dynamic> items)
        {
            var respItems = new List<dynamic>();
            foreach (var item in items)
            {
                ICD9ResponseCodeModel responseItem = BuildResponseItem(item);
                respItems.Add(responseItem);
            }

            return respItems;
        }

        public static ICD9ResponseCodeModel BuildResponseItem(dynamic item)
        {
            var responseItem = new ICD9ResponseCodeModel();
            responseItem.Code = item.Code;
            responseItem.LongDescription = item.LongDescription;
            responseItem.ShortDescription = item.ShortDescription;
            responseItem.Version = item.Version;
            return responseItem;
        }
    }
}
