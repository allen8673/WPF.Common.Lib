using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
using WPF.Common.Ctrls.Dialog;
using WPF.Common.Ctrls.Loading;
using WPF.Common.Ctrls.Permission;

namespace WPF.Common.Demo
{
    /// <summary>
    /// MainWindow.xaml 的互動邏輯
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            PermissionCtrl.RegisterVisibilityRule((str) => str == "HasPermission");
            InitializeComponent();
        }

        private async void LoadingBtn_Click(object sender, RoutedEventArgs e)
        {
            using (var progresser = new Progresser())
            {
                await Task.Run(() =>
                {
                    Thread.Sleep(3000);
                });
            }
        }

        private async void LoadingBtn2_Click(object sender, RoutedEventArgs e)
        {
            using (var progresser = new Progresser(ctrl: new CustomLoading()))
            {
                await Task.Run(() =>
                {
                    Thread.Sleep(3000);
                });
            }
        }

        private void DialogBtn_Click(object sender, RoutedEventArgs e)
        {
            DialogFactory.Generate(DialogType.Confirm, ButtonType.Single, "Single button dialog").ShowDialog();
        }

        private void TwinDialogBtn_Click(object sender, RoutedEventArgs e)
        {
            DialogFactory.Generate(DialogType.Confirm, ButtonType.Twin, "Twin button dialog").ShowDialog();
        }
    }
}
