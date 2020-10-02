using System;
using System.Collections.Generic;

namespace CMRmvc.Models
{
    public partial class RolesAcciones
    {
        public long IdPerfilAccion { get; set; }
        public long IdRol { get; set; }
        public long IdMenuHijoAccion { get; set; }

        public virtual MenuHijoAcciones IdMenuHijoAccionNavigation { get; set; }
    }
}
