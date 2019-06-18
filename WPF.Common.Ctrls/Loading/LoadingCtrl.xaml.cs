using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// LoadingCtrl.xaml 的互動邏輯
    /// </summary>
    public partial class LoadingCtrl : UserControl
    {

        public LoadingCtrl()
        {
            InitializeComponent();
            InitializeLoadingCtrl();
        }

        private void InitializeLoadingCtrl()
        {
            DependencyPropertyDescriptor dpd =
                DependencyPropertyDescriptor.FromProperty(LoadingCtrl.VisibilityProperty, this.GetType());
            if (dpd != null)
            {
                dpd.AddValueChanged(this, (sender, e) =>
                {
                    LoadingCtrl element = sender as LoadingCtrl;
                    element.Visibility = Progresser.Progress.Progressing ? Visibility.Visible : Visibility.Collapsed;
                });
            }

            Binding binding = new Binding
            {
                Path = new PropertyPath("Progressing"),
                Source = Progresser.Progress,
                Mode = BindingMode.TwoWay,
                UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged,
                Converter = new Progresser.ProgressingConverter()
            };
            this.SetBinding(LoadingCtrl.VisibilityProperty, binding);

        }
    }
}
