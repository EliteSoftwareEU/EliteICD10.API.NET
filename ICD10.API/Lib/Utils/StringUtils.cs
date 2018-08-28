using System;
using System.Text.RegularExpressions;

namespace ICD10.API.Lib.Utils
{
    public static class StringUtils
    {
        public static string SplitCamelCase(this string source)
        {
            return string.Join(" ", Regex.Split(source, @"(?<!^)(?=[A-Z])"));
        }
    }
}