using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WPF.Common.Service.Extends;

namespace WPF.Common.Ctrls.Permission
{
    public class PermissionCtrl
    {
        #region Visibility DependencyProperty
        public static readonly DependencyProperty VisibilityProperty =
           DependencyProperty.RegisterAttached("Visibility", typeof(string), typeof(PermissionCtrl), new PropertyMetadata(Visibility_callback));

        public static void SetVisibility(UIElement element, string value)
        {
            element.SetValue(VisibilityProperty, value);
        }

        public static string GetVisibility(UIElement element)
        {
            return (string)element.GetValue(VisibilityProperty);
        }

        private static void Visibility_callback(DependencyObject source, DependencyPropertyChangedEventArgs e)
        {
            var element = (UIElement)source;
            string permission = GetVisibility(element);

            if (PermissionManager.Content[permission, element] != null)
                return;

            #region Permission control process
            PermissionManager.Content.Add(permission, element);
            CalculateElementVisibility(element);

            DependencyPropertyDescriptor dpd =
                DependencyPropertyDescriptor.FromProperty(UIElement.VisibilityProperty, source.GetType());
            if (dpd != null)
            {
                dpd.AddValueChanged(source, VisibilityChange);
            }
            #endregion
        }
        #endregion

        #region Visibility Process Methods
        private static void VisibilityChange(object sender, EventArgs e)
        {
            UIElement element = sender as UIElement;
            CalculateElementVisibility(element);

        }

        private static Func<string, bool> VisibilityRule { get; set; } = (element) => true;
        public static void RegisterVisibilityRule(Func<string, bool> rule)
            => VisibilityRule = rule ?? ((str) => { return true; });

        private static void CalculateElementVisibility(UIElement element)
        {
            if (VisibilityRule(GetVisibility(element)))
            {
                element.ClearValue(UIElement.VisibilityProperty);
            }
            else
            {
                element.Visibility = Visibility.Collapsed;
            }
        }

        public static bool IsVisible(UIElement element)
        {
            return VisibilityRule(GetVisibility(element));
        }
        #endregion

    }
}
