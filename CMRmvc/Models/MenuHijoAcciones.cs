using Newtonsoft.Json;
using System.Collections.Generic;

namespace CMRmvc.Models
{
    public partial class MenuHijoAcciones
    {
        public MenuHijoAcciones()
        {
            //RolesAcciones = new HashSet<RolesAcciones>();
        }

        public long IdMenuHijoAccion { get; set; }
        public long IdMenuHijo { get; set; }
        public string MhaKey { get; set; }
        public string MhaIcono { get; set; }
        public string MhaTooltip { get; set; }
        public string MhaClase { get; set; }
        public int? MhaOrden { get; set; }
        public bool? MhaNewTab { get; set; }
        public string MhaUrl { get; set; }
        public string MhaTexto { get; set; }
        [JsonIgnore]
        public virtual MenuItemHijo IdMenuHijoNavigation { get; set; }
        public virtual List<RolesAcciones> RolesAcciones { get; set; }
    }
}
