using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace WPF.Common.Service.Extends
{
    public static class EnumExtd
    {
        public static T GetAttribute<T>(this Enum en)
            where T : Attribute
        {
            FieldInfo fieldInfo = en.GetType().GetField(en.ToString());
            if (fieldInfo == null) return null;
            return fieldInfo.GetCustomAttribute<T>();
        }
    }
}
