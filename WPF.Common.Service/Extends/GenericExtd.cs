using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF.Common.Service.Extends
{
    public static class GenericExtd
    {
        public static bool IsNullOrEmpty<T>(this T v)
        {
            if (v is string)
            {
                if (v.ToString() == "")
                    return true;
            }
            if (v == null)
                return true;
            return false;
        }

        public static bool IsNullOrEmpty<T>(this T? v) where T : struct
        {
            if (v == null)
                return true;
            return false;
        }

        public static string NullAs<T>(this T v, string replace)
        {
            if (v == null)
                return replace;
            return v.ToString();
        }
    }
}
