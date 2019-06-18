using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF.Common.Service.Extends
{
   public static class DoubleExtd
    {
        public static bool IsNullOrEmpty(this double? v)
        {
            if (v == null)
                return true;
            return false;
        }
    }
}
