using System.Collections.Generic;

namespace CMRmvc.Models
{
    public class RoleViewModel : Role
    {
        public List<MenuItemPadre> Menu { get; set; }
        public List<RolesAcciones> RolesAcciones { get; set; }

        public List<PerfilMenuHijo> PerfilMenuHijo { get; set; }

    }
}
