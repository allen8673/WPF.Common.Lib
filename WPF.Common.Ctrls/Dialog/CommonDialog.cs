using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace WPF.Common.Ctrls.Dialog
{
    public class CommonDialog : Window
    {
        public static readonly DependencyProperty IconSourceProperty = DependencyProperty.Register("IconSource", typeof(ImageSource), typeof(CommonDialog), null);
        public static readonly DependencyProperty LabelProperty = DependencyProperty.Register("Label", typeof(string), typeof(CommonDialog), null);
        public static readonly DependencyProperty ConfirmLableProperty = DependencyProperty.Register("ConfirmLable", typeof(string), typeof(CommonDialog), null);

        public ImageSource IconSource
        {
            get { return (ImageSource)this.GetValue(IconSourceProperty); }
            set { this.SetValue(IconSourceProperty, value); }
        }
        public string Label
        {
            get { return (string)this.GetValue(LabelProperty); }
            set { this.SetValue(LabelProperty, value); }
        }
        public string ConfirmLabel
        {
            get { return (string)this.GetValue(ConfirmLableProperty); }
            set { this.SetValue(ConfirmLableProperty, value); }
        }
    }
}
