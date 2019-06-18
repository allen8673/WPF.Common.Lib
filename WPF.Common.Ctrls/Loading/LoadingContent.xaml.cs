using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPF.Common.Ctrls.Loading
{
    /// <summary>
    /// LoadingContent.xaml 的互動邏輯
    /// </summary>
    public partial class LoadingContent : UserControl
    {
        public static readonly DependencyProperty RingSizeProperty = DependencyProperty.Register("RingSize", typeof(GridLength), typeof(LoadingCtrl), null);
        public GridLength RingSize
        {
            get { return (GridLength)this.GetValue(RingSizeProperty); }
            set { this.SetValue(RingSizeProperty, value); }
        }
        public LoadingContent()
        {
            InitializeComponent();
        }
    }
}
