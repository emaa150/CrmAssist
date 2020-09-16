using System;
using System.Collections.Generic;

namespace CMRmvc.Models
{
    public partial class MenuItemHijo
    {
        public MenuItemHijo()
        {
            MenuHijoAcciones = new HashSet<MenuHijoAcciones>();
            PerfilMenuHijo = new HashSet<PerfilMenuHijo>();
        }

        public long IdMenuHijo { get; set; }
        public long IdMenuPadre { get; set; }
        public string Nombr { get; set; }
        public string Controlador { get; set; }
        public string Accion { get; set; }
        public string Icono { get; set; }

        public virtual MenuItemPadre IdMenuPadreNavigation { get; set; }
        public virtual ICollection<MenuHijoAcciones> MenuHijoAcciones { get; set; }
        public virtual ICollection<PerfilMenuHijo> PerfilMenuHijo { get; set; }
    }
}
