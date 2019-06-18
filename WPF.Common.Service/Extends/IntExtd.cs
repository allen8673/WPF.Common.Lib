using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF.Common.Service.Extends
{
    public static class IntExtd
    {
        public static bool IsNullOrEmpty(this int? v)
        {
            if (v == null)
                return true;
            return false;
        }

        public static string ToDayHourMinuteString(this int seconds)
        {
            if (seconds == -1)
                return " unknown ";// "-1";
            string msg = "";
            var days = seconds / (60 * 60 * 24);
            seconds -= days * (60 * 60 * 24);
            var hours = seconds / (60 * 60);
            seconds -= hours * (60 * 60);
            var minutes = seconds / 60;
            if (days > 0)
                msg += " " + days + " day";
            if (hours > 0)
                msg += " " + hours + " hrs";
            if (minutes > 0)
                msg += " " + minutes + " minutes";
            return msg;
        }
    }
}
