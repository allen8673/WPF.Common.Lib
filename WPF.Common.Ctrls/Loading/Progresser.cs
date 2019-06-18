using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using WPF.Common.Service.Model;

namespace WPF.Common.Ctrls.Loading
{
    public class Progresser : PropertyObserver<Progresser>, IDisposable
    {
        public static Progresser Progress { get; private set; } = new Progresser(false, new LoadingContent
        {
            RingSize =  new GridLength(1, GridUnitType.Star)
        });
        private int ProgressingCount { get; set; }
        public UserControl LoadingCtrl
        {
            get => GetValue<UserControl>();
            private set => SetValue(value);
        }

        public bool Progressing
        {
            get => GetValue<bool>();
            set => SetValue(value);
        }

        public bool PredictProgressing
        {
            get => GetValue<bool>();
        }

        public Progresser(bool progress = true, UserControl ctrl = null)
        {
            Progress = Progress ?? this;
            Progress.Progressing = progress;
            Progress.LoadingCtrl = ctrl ?? new LoadingContent
            {
                RingSize =  new GridLength(1, GridUnitType.Star)
            };
            if (progress)
            {
                Progress.ProgressingCount++;
            }
        }

        public void Dispose()
        {
            if (--Progress.ProgressingCount == 0)
            {
                Progress.Progressing = false;
            }
        }

        public class ProgressingConverter : IValueConverter
        {
            public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
            {
                return (bool)value ? Visibility.Visible : Visibility.Collapsed;
            }

            public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            {
                return (Visibility)value == Visibility.Visible;
            }
        }
    }
}