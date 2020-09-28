using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;

namespace CMRmvc.Models
{
    public partial class RolesAcciones
    {
        public long IdPerfilAccion { get; set; }
        public long IdRol { get; set; }
        public long IdMenuHijoAccion { get; set; }

        [JsonIgnore]
        public virtual MenuHijoAcciones IdMenuHijoAccionNavigation { get; set; }
    }
}
