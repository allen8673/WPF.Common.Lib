using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace WPF.Common.Service.Extends
{
    public static class DependencyObjectExtd
    {
        public static IEnumerable<T> FindVisualChildren<T>(this DependencyObject depObj) where T : DependencyObject
        {
            if (depObj != null)
            {
                for (int i = 0; i < VisualTreeHelper.GetChildrenCount(depObj); i++)
                {
                    DependencyObject child = VisualTreeHelper.GetChild(depObj, i);
                    if (child != null && child is T)
                    {
                        yield return (T)child;
                    }

                    foreach (T childOfChild in FindVisualChildren<T>(child))
                    {
                        yield return childOfChild;
                    }
                }
            }
        }

        public static T FindVisualParent<T>(this DependencyObject depObj) where T : DependencyObject
        {
            if (depObj != null)
            {
                var fe = (depObj as FrameworkElement);
                if (fe != null && fe.Parent is T)
                    return fe.Parent as T;

                var parent = VisualTreeHelper.GetParent(depObj);
                return parent is T ? parent as T : FindVisualParent<T>(parent);
            }
            return default(T);
        }
    }
}
