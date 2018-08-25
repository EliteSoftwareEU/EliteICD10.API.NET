using System;
using System.Collections.Generic;

namespace ICD10.API.Models.Response
{
    public abstract class BaseResponseModel
    {
        public static List<dynamic> BuildResponseItems(List<dynamic> items)
        {
            var respItems = new List<dynamic>();
            foreach (var item in items)
            {
                ICD10ResponseCategoryModel responseItem = BuildResponseItem(item);
                respItems.Add(responseItem);
            }

            return items;
        }

        private static ICD10ResponseCategoryModel BuildResponseItem(dynamic item)
        {
            throw new NotImplementedException();
        }
    }
}
