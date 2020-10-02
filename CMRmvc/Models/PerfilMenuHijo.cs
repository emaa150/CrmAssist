using System;
using System.Collections.Generic;

namespace CMRmvc.Models
{
    public partial class PerfilMenuHijo
    {
        public long IdPerfilMenuHijo { get; set; }
        public long IdRol { get; set; }
        public long IdMenuHijo { get; set; }

        public virtual MenuItemHijo IdMenuHijoNavigation { get; set; }
    }
}
