using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WPF.Common.Service;
using WPF.Common.Service.Extends;
using WPF.Common.Styles.Resource.SVGImages;

namespace WPF.Common.Ctrls.Dialog
{
    public class DialogFactory
    {
        public static Window Owner { get; set; } = null;
        public static CommonDialog Generate(DialogType type, ButtonType btnType, string text, string btnText = null)
        {
            CommonDialog dialog;
            switch (btnType)
            {
                default:
                case ButtonType.Single:
                    dialog = new SingleBtnDialog();
                    break;
                case ButtonType.Twin:
                    dialog = new TwinBtnDialog();
                    break;
            }

            //TwinBtnDialog dialog;
            switch (type)
            {
                default:
                case DialogType.Confirm:
                    dialog.Icon = ImageService.GetSVGBitmap(SvgIcons.Dialog_complete_icon.GetPath());
                    dialog.Label = text;
                    dialog.ConfirmLabel = btnText ?? "確定";
                    if (dialog is TwinBtnDialog)
                    {
                        ((TwinBtnDialog)dialog).CancelLabel = "取消";
                    }
                    break;
                case DialogType.AlterationConfirm:
                    dialog.Icon = ImageService.GetSVGBitmap(SvgIcons.Dialog_popup_copy_icon.GetPath());
                    dialog.Label = text;
                    dialog.ConfirmLabel = btnText ?? "確定";
                    if (dialog is TwinBtnDialog)
                    {
                        ((TwinBtnDialog)dialog).CancelLabel = "取消";
                    }
                    break;
                case DialogType.Warning:
                    dialog.Icon = ImageService.GetSVGBitmap(SvgIcons.Dialog_alter_icon.GetPath());
                    dialog.Label = text;
                    dialog.ConfirmLabel = btnText ?? "確定";
                    if (dialog is TwinBtnDialog)
                    {
                        ((TwinBtnDialog)dialog).CancelLabel = "取消";
                    }
                    break;
                case DialogType.Delete:
                    dialog.Icon = ImageService.GetSVGBitmap(SvgIcons.Dialog_delete_icon.GetPath());
                    dialog.Label = text;
                    dialog.ConfirmLabel = "確認刪除";
                    if (dialog is TwinBtnDialog)
                    {
                        ((TwinBtnDialog)dialog).CancelLabel = "取消";
                    }
                    break;
                case DialogType.Update:
                    dialog.Icon = ImageService.GetSVGBitmap(SvgIcons.Dialog_update_icon.GetPath());
                    dialog.Label = text;
                    dialog.ConfirmLabel = btnText ?? "確定";

                    if (dialog is TwinBtnDialog)
                    {
                        ((TwinBtnDialog)dialog).CancelLabel = "取消";
                    }
                    break;
                case DialogType.Upload:
                    dialog.Icon = ImageService.GetSVGBitmap(SvgIcons.Dialog_upload_icon.GetPath());
                    dialog.Label = text;
                    dialog.ConfirmLabel = btnText ?? "確定";
                    if (dialog is TwinBtnDialog)
                    {
                        ((TwinBtnDialog)dialog).CancelLabel = "取消";
                    }
                    break;
                case DialogType.Question:
                    dialog.Icon = ImageService.GetSVGBitmap(SvgIcons.Dialog_question_icon.GetPath());
                    dialog.Label = text;
                    dialog.ConfirmLabel = "好，我知道了";
                    if (dialog is TwinBtnDialog)
                    {
                        ((TwinBtnDialog)dialog).CancelLabel = "取消";
                    }
                    break;
            }

            if (!Owner.IsNullOrEmpty())
            {
                dialog.Owner = Owner;
            }
            else
            {
                dialog.Owner = Application.Current.MainWindow;
            }

            if (dialog.Owner.WindowState == WindowState.Maximized)
            {
                var handle = new System.Windows.Interop.WindowInteropHelper(dialog.Owner).Handle;
                var screen = System.Windows.Forms.Screen.FromHandle(handle);
                var area = screen.WorkingArea;

                dialog.Left = area.Left;
                dialog.Top = area.Top;
                dialog.Width = area.Width;
                dialog.Height = area.Height;
            }
            else
            {
                dialog.Left = dialog.Owner.Left;
                dialog.Top = dialog.Owner.Top;
                dialog.Width = dialog.Owner.ActualWidth;
                dialog.Height = dialog.Owner.ActualHeight;
            }

            return dialog;
        }
    }

    public enum DialogType
    {
        Confirm,
        AlterationConfirm,
        Warning,
        Delete,
        Update,
        Upload,
        Question

    }

    public enum ButtonType
    {
        Single,
        Twin
    }
}
