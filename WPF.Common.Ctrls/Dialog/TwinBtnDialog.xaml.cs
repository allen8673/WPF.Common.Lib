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
using System.Windows.Shapes;

namespace WPF.Common.Ctrls.Dialog
{
    /// <summary>
    /// TwinBtnDialog.xaml 的互動邏輯
    /// </summary>
    public partial class TwinBtnDialog : CommonDialog
    {
        public static readonly DependencyProperty CancelLabelProperty = DependencyProperty.Register("CancelLabel", typeof(string), typeof(TwinBtnDialog), null);
        public string CancelLabel
        {
            get { return (string)this.GetValue(CancelLabelProperty); }
            set { this.SetValue(CancelLabelProperty, value); }
        }

        public TwinBtnDialog()
        {
            InitializeComponent();
        }

        private void BtnConfirm_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
        public TextBlock GetTbInfo() => TbInfo;
    }
}
