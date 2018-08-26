using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ICD10.API.Models.Response
{
    public class ICD10ResponseCategoryModel : BaseResponseModel
    {
        public string Code { get; set; }
        public string Title { get; set; }
        public List<ICD10ResponseCodeModel> Codes { get; set; } = new List<ICD10ResponseCodeModel>();

        public static new List<dynamic> BuildResponseItems(List<dynamic> items)
        {
            var respItems = new List<dynamic>();
            foreach (var item in items)
            {
                ICD10ResponseCategoryModel responseItem = BuildResponseItem(item);
                respItems.Add(responseItem);
            }

            return respItems;
        }

        public static ICD10ResponseCategoryModel BuildResponseItem(dynamic item)
        {
            var responseItem = new ICD10ResponseCategoryModel();
            responseItem.Code = item.Code;
            responseItem.Title = item.Title;
            foreach(ICD10Code code in item.ICD10Codes)
            {
                responseItem.Codes.Add(ICD10ResponseCodeModel.BuildResponseItem(code));
            }
            return responseItem;
        }
    }
}
