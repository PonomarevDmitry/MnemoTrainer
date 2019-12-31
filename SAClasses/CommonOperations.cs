using System;
using System.Text;
using System.Text.RegularExpressions;

namespace SAClasses
{
    internal static class CommonOperations
    {
        internal static Random rnd;

        static CommonOperations()
        {
            rnd = new Random();
        }

        internal static bool MatchPattern(string target, string pattern)
        {
            string patternTemp = ConvertToMatchFormat(pattern);
            string targetTemp = ConvertToMatchFormat(target);

            return targetTemp.Contains(patternTemp);
        }

        private static string ConvertToMatchFormat(string str)
        {
            StringBuilder result = new StringBuilder(str.ToLower());

            result = result.Replace(" ", "");
            result = result.Replace(".", "");
            result = result.Replace(",", "");
            result = result.Replace("-", "");

            return RemoveDoubleSymbols(result);
        }

        private static string RemoveDoubleSymbols(StringBuilder strBuilder)
        {
            Regex doubleSymbolPattern = new Regex(@"(?<Ch>.{1})\k<Ch>");

            while (doubleSymbolPattern.IsMatch(strBuilder.ToString()))
            {
                MatchCollection matches = doubleSymbolPattern.Matches(strBuilder.ToString());

                foreach (Match item in matches)
                {
                    string value = item.Groups["Ch"].Value;

                    strBuilder = strBuilder.Replace(value + value, value);
                }
            }

            return strBuilder.ToString();
        }
    }
}
