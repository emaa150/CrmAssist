using CMRmvc.Interface;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CMRmvc.Models
{
    public partial class MenuItemPadre : ICheckedProperty
    {
        public MenuItemPadre()
        {
            //MenuItemHijo = new HashSet<MenuItemHijo>();
        }

        public long IdMenuPadre { get; set; }
        public string Nombre { get; set; }
        public string Icono { get; set; }

        [NotMapped]
        public bool IsChecked { get; set; }

        public virtual List<MenuItemHijo> MenuItemHijo { get; set; }
    }
}
