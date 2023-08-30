using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace SalaryManagement.Common
{
    public static class FormulaValidate
    {
        public static string ReplaceAll(string input, string pattern, string replace)
        {
            pattern = @"\b" + pattern + @"\b";
            string result = Regex.Replace(input, pattern, replace, RegexOptions.IgnoreCase);

            return result;
        }

        public static IEnumerable<int> AllIndexesOf(this string str, string searchstring)
        {
            int minIndex = str.IndexOf(searchstring);
            while (minIndex != -1)
            {
                yield return minIndex;
                minIndex = str.IndexOf(searchstring, minIndex + searchstring.Length);
            }
        }

        public static bool CheckFormula(string fAttribute, string formula)
        {
            bool check = true;

            string strFormula = " " + formula + " ";

            foreach (var index in AllIndexesOf(strFormula, fAttribute))
            {
                if (index == -1)
                {
                    return true;
                }

                string strRegex = @"[a-zA-Z]";
                var iFirst = strFormula[index - 1].ToString();
                var iLast = strFormula[index + fAttribute.Length].ToString();
                Regex re = new(strRegex);
                if (!re.IsMatch(iFirst) && !re.IsMatch(iLast))
                {
                    check = false;
                    break;
                }
            }

            return check;
        }
    }
}
