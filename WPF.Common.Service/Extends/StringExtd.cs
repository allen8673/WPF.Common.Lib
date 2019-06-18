using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WPF.Common.Service.Extends
{
    public static class StringExtd
    {
        public static string ReplaceAll(this string v, string pattern, string replaceAs)
        {
            Regex digitsOnly = new Regex(pattern);
            return digitsOnly.Replace(v, replaceAs);
        }

        public static bool IsMatch(this string v, string pattern, RegexOptions option = RegexOptions.IgnoreCase)
        {
            Regex r = new Regex(pattern, option);
            return r.IsMatch(v);
        }

        public static bool ContainList(this string v, IEnumerable<string> compares)
        {
            if (v.IsNullOrEmpty())
                return false;
            if (compares.Count() == 1)
                return v.Contains(compares.First());
            foreach (var dr in compares)
            {
                if (v.Contains(dr))
                    return true;
            }
            return false;
        }
    }

}
