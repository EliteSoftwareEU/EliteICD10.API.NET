using System.Collections.Generic;
using System.Linq;
using ICD10.API.Lib.CodesMapping;
using ICD10.API.Lib.Utils;
namespace ICD10.API.Lib
{
    public class MappingFlagsResolver
    {
        readonly string _flags;

        public MappingFlagsResolver(string flags)
        {
            _flags = flags;
        }

        public Dictionary<string, string> Resolve()
        {
            var flagsList = new Dictionary<string, string>();
            flagsList.Add("MappingType", GetMapingTypeFlag().ToString().SplitCamelCase());
            flagsList.Add("MappingCount",GetMappingCountFlag().ToString().SplitCamelCase());
            flagsList.Add("MappingCombination", GetMappingCombinationFlag().ToString().SplitCamelCase());

            return flagsList;
        }

        private MappingType GetMapingTypeFlag()
        {
            string mappingTypeFlag = _flags.Substring(0, 1);
            if (mappingTypeFlag == "1")
                return MappingType.Approximate;
            else
                return MappingType.Identical;
        }

        private MappingCount GetMappingCountFlag()
        {   
            string mappingCountFlag = _flags.Substring(1, 1);
            if (mappingCountFlag == "1")
                return MappingCount.NoMapping;
            else
                return MappingCount.AtLeastOneMapping;
        }

        private MappingCombination GetMappingCombinationFlag()
        {
            string mappingCountFlag = _flags.Substring(2, 1);
            if (mappingCountFlag == "0")
                return MappingCombination.SingleCode;
            else
                return MappingCombination.MoreThanOneCode;
        }
    }
}
