using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ICD10.API.Models.Response
{
    public class ICD10ResponseCodeModel : BaseResponseModel
    {
        public string CategoryCode { get; set; }
        public string DiagnosisCode { get; set; }
        public string FullCode { get; set; }
        public string AbbreviatedDescription { get; set; }
        public string FullDescription { get; set; }
        public string CategoryTitle { get; set; }        

        public static new List<dynamic> BuildResponseItems(List<dynamic> items)
        {
            var respItems = new List<dynamic>();
            foreach (var item in items)
            {
                var responseItem = BuildResponseItem(item);
                respItems.Add(responseItem);
            }
            return respItems;
        }

        public static ICD10ResponseCodeModel BuildResponseItem(dynamic item)
        {
            var responseItem = new ICD10ResponseCodeModel();
            responseItem.AbbreviatedDescription = item.AbbreviatedDescription;
            responseItem.CategoryCode = item.Category.Code;
            responseItem.CategoryTitle = item.Category.Title;
            responseItem.DiagnosisCode = item.DiagnosisCode;
            responseItem.FullCode = item.FullCode;
            responseItem.FullDescription = item.FullDescription;
            return responseItem;
        }
    }
}
