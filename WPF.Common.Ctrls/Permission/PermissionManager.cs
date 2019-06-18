using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WPF.Common.Ctrls.Permission
{
    internal class PermissionManager : HashSet<PermissionDetail>
    {
        /// <summary>
        /// constructor
        /// </summary>
        private PermissionManager() { }
        /// <summary>
        /// Manager content
        /// </summary>
        public static PermissionManager Content { get; private set; } = new PermissionManager();
        public IEnumerable<PermissionDetail> this[string name] => this.Where(i => i.PermissionName == name);
        public new PermissionDetail this[string name, UIElement ctrl] => this.FirstOrDefault(i => i.PermissionName == name && i.Control == ctrl);
        public void Add(string name, UIElement ctrl) => base.Add(new PermissionDetail
        {
            PermissionName = name,
            Control = ctrl
        });
    }

    internal class PermissionDetail
    {
        public string PermissionName { get; set; }
        public UIElement Control { get; set; }
        public Action VisibilityAct { get; set; }
    }
}
