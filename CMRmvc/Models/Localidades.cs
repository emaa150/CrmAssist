using System;
using System.Collections.Generic;

namespace CMRmvc.Models
{
    public partial class Localidades
    {
        public Localidades()
        {
            Clientes = new HashSet<Clientes>();
        }

        public long IdLocalidad { get; set; }
        public string Nombre { get; set; }
        public long? IdProvincia { get; set; }

        public virtual Provincias IdProvinciaNavigation { get; set; }
        public virtual ICollection<Clientes> Clientes { get; set; }
    }
}
