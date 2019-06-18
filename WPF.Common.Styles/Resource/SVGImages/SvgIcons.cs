using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF.Common.Service.Extends;

namespace WPF.Common.Styles.Resource.SVGImages
{
    public enum SvgIcons
    {
        [Description(@"")]
        None,
        //Main Menu
        [Description(@"SVGImages\main menu\main menu_bus stop_f.svg")]
        Main_Menu_bus_stop_f,

        [Description(@"SVGImages\main menu\main menu_bus stop_n.svg")]
        Main_Menu_bus_stop_n,

        [Description(@"SVGImages\main menu\main menu_equipment_f.svg")]
        Main_Menu_equipment_f,

        [Description(@"SVGImages\main menu\main menu_equipment_n.svg")]
        Main_Menu_equipment_n,

        [Description(@"SVGImages\main menu\main menu_map view_f.svg")]
        Main_Menu_map_view_f,

        [Description(@"SVGImages\main menu\main menu_map view_n.svg")]
        Main_Menu_map_view_n,

        [Description(@"SVGImages\main menu\main menu_setting_f.svg")]
        Main_Menu_setting_f,

        [Description(@"SVGImages\main menu\main menu_setting_n.svg")]
        Main_Menu_setting_n,

        [Description(@"SVGImages\main menu\main menu_sign_f.svg")]
        Main_Menu_sign_f,

        [Description(@"SVGImages\main menu\main menu_sign_n.svg")]
        Main_Menu_sign_n,

        [Description(@"SVGImages\main menu\main menu_instant traffic_n.svg")]
        Main_Menu_instant_traffic_n,

        [Description(@"SVGImages\main menu\main menu_route_n.svg")]
        Main_Menu_route_n,

        [Description(@"SVGImages\main menu\main menu_vehicle_n.svg")]
        Main_Menu_vehicle_n,

        [Description(@"SVGImages\main menu\main menu_news_n.svg")]
        Main_Menu_news_n,

        [Description(@"SVGImages\main menu\main menu_vehicle alert_n.svg")]
        Main_Menu_vehicle_alert_n,

        [Description(@"SVGImages\main menu\main menu_vehicle_f.svg")]
        Main_Menu_vehicle_f,

        //Map
        [Description(@"SVGImages\map\map_accident.svg")]
        Map_accident,

        [Description(@"SVGImages\map\map_bus stop.svg")]
        Map_bus_stop,

        [Description(@"SVGImages\map\map_cctv.svg")]
        Map_cctv,

        [Description(@"SVGImages\map\map_construction.svg")]
        Map_construction,

        [Description(@"SVGImages\map\map_sign.svg")]
        Map_sign,

        [Description(@"SVGImages\map\map_vehicle.svg")]
        Map_vehicle,

        //Side Menu
        [Description(@"SVGImages\side menu\side menu_accident.svg")]
        Side_menu_accident,

        [Description(@"SVGImages\side menu\side menu_all.svg")]
        Side_menu_all,

        [Description(@"SVGImages\side menu\side menu_bus stop.svg")]
        Side_menu_bus_stop,

        [Description(@"SVGImages\side menu\side menu_route vehicle list.svg")]
        Side_menu_route_vehicle_list,

        [Description(@"SVGImages\side menu\side menu_bus stop list.svg")]
        Side_menu_bug_stop_list,

        [Description(@"SVGImages\side menu\side menu_route info.svg")]
        Side_menu_route_info,

        [Description(@"SVGImages\side menu\side menu_cctv.svg")]
        Side_menu_cctv,

        [Description(@"SVGImages\side menu\side menu_cctv_full screen.svg")]
        Side_menu_cctv_full_screen,

        [Description(@"SVGImages\side menu\side menu_delete_f.svg")]
        Side_menu_delete_f,

        [Description(@"SVGImages\side menu\side menu_delete_f_1.svg")]
        Side_menu_delete_f_1,

        [Description(@"SVGImages\side menu\side menu_edit_f.svg")]
        Side_menu_edit_f,

        [Description(@"SVGImages\side menu\side menu_edit_n.svg")]
        Side_menu_edit_n,

        [Description(@"SVGImages\side menu\side menu_add_bus_f.svg")]
        Side_menu_add_f,

        [Description(@"SVGImages\side menu\side menu_add_bus_n.svg")]
        Side_menu_add_n,

        [Description(@"SVGImages\side menu\side menu_list_edit.svg")]
        Side_menu_list_edit,

        [Description(@"SVGImages\side menu\side menu_list_delete.svg")]
        Side_menu_list_delete,

        [Description(@"SVGImages\side menu\side menu_list_daggle.svg")]
        Side_menu_list_daggle,

        [Description(@"SVGImages\side menu\side menu_equipment.svg")]
        Side_menu_equipment,

        [Description(@"SVGImages\side menu\side menu_sign.svg")]
        Side_menu_sign,

        [Description(@"SVGImages\side menu\side menu_vehicle.svg")]
        Side_menu_vehicle,

        //VerificationTextBoxCtrl
        [Description(@"SVGImages\side menu\side menu_frame_confirm icon.svg")]
        Validate_Success,

        //Top Bar
        [Description(@"SVGImages\top bar\search icon.svg")]
        Top_bar_search_icon,

        [Description(@"SVGImages\top bar\taiwan-national-development-council.png")]
        Top_bar_TNDC,

        //Hamburger Button
        [Description(@"SVGImages\HamburgerBtn\main menu_lengthen.svg")]
        Main_menu_lengthen,

        [Description(@"SVGImages\HamburgerBtn\main menu_shorten.svg")]
        Main_menu_shorten,

        //Navigation Btn
        [Description(@"SVGImages\navigation\btn_import file.svg")]
        Navigation_btn_import_file,

        [Description(@"SVGImages\navigation\btn_new add icon.svg")]
        Navigation_btn_new_add_icon,

        // Equipment
        [Description(@"SVGImages\Equipment\btn_refresh.svg")]
        Equipment_btn_refresh,

        [Description(@"SVGImages\Equipment\sign_green.svg")]
        Equipment_sign_green,

        [Description(@"SVGImages\Equipment\sign_red flash.svg")]
        Equipment_sign_red_flash,

        [Description(@"SVGImages\Equipment\sign_red.svg")]
        Equipment_sign_red,

        [Description(@"SVGImages\Equipment\sign_yellow flash.svg")]
        Equipment_sign_yellow_flash,

        // Dialog
        [Description(@"SVGImages\Dialog\error_alert.svg")]
        Dialog_error_alert,

        [Description(@"SVGImages\Dialog\popup_alter icon.svg")]
        Dialog_alter_icon,

        [Description(@"SVGImages\Dialog\popup_complete icon.svg")]
        Dialog_complete_icon,

        [Description(@"SVGImages\Dialog\popup_delete icon.svg")]
        Dialog_delete_icon,

        [Description(@"SVGImages\Dialog\popup_exit icon.svg")]
        Dialog_exit_icon,

        [Description(@"SVGImages\Dialog\popup_copy icon.svg")]
        Dialog_popup_copy_icon,

        [Description(@"SVGImages\Dialog\popup_update icon.svg")]
        Dialog_update_icon,

        [Description(@"SVGImages\Dialog\popup_upload icon.svg")]
        Dialog_upload_icon,

        [Description(@"SVGImages\Dialog\popup_question icon.svg")]
        Dialog_question_icon,

        // Other 
        [Description(@"SVGImages\other\traffic event_list_show map.svg")]
        Traffic_event_list_show_map,

        [Description(@"SVGImages\other\action_play.svg")]
        Action_play,

        [Description(@"SVGImages\other\action_lock.svg")]
        Action_lock,

        [Description(@"SVGImages\other\action_key.svg")]
        Action_key,

        [Description(@"SVGImages\other\action_upload.svg")]
        Action_upload,

        [Description(@"SVGImages\other\attachment_icon.svg")]
        Attachment_icon,

        [Description(@"SVGImages\Display\dashboard_nodata_accident.svg")]
        Dashboard_nodata_accident,

        [Description(@"SVGImages\Display\dashboard_nodata_cctv.svg")]
        Dashboard_nodata_cctv,

        [Description(@"SVGImages\other\action icon_view.svg")]
        Action_icon_view,

        [Description(@"SVGImages\other\tag_exception.svg")]
        tag_error,

        [Description(@"SVGImages\other\tag_warning.svg")]
        tag_warning,

        [Description(@"SVGImages\other\tag_caution.svg")]
        tag_caution,

        [Description(@"SVGImages\other\icon img_cctv.svg")]
        Icon_img_cctv,
    }

    public static class SvgIconsExtd
    {
        public static string GetPath(this SvgIcons icon)
        {
            string path = icon.GetAttribute<DescriptionAttribute>().Description;
            return Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "Resource", path);
        }
    }
}
