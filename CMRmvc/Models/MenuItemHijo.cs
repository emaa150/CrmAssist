using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CMRmvc.Models
{
    public partial class MenuItemHijo
    {
        public MenuItemHijo()
        {
            //   MenuHijoAcciones = new HashSet<MenuHijoAcciones>();
            PerfilMenuHijo = new HashSet<PerfilMenuHijo>();
        }

        public long IdMenuHijo { get; set; }
        public long IdMenuPadre { get; set; }
        public string Nombr { get; set; }
        public string Controlador { get; set; }
        public string Accion { get; set; }
        public string Icono { get; set; }

        [NotMapped]
        public bool IsChecked { get; set; }

        [JsonIgnore]
        public virtual MenuItemPadre IdMenuPadreNavigation { get; set; }
        public virtual List<MenuHijoAcciones> MenuHijoAcciones { get; set; }
        public virtual ICollection<PerfilMenuHijo> PerfilMenuHijo { get; set; }
    }
}