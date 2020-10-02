using System.Collections.Generic;

namespace CMRmvc.Models
{
    public partial class MenuItemPadre
    {
        public MenuItemPadre()
        {
            //MenuItemHijo = new HashSet<MenuItemHijo>();
        }

        public long IdMenuPadre { get; set; }
        public string Nombre { get; set; }
        public string Icono { get; set; }

        public virtual List<MenuItemHijo> MenuItemHijo { get; set; }
    }
}
