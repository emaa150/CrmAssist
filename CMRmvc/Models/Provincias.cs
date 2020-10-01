using System;
using System.Collections.Generic;

namespace CMRmvc.Models
{
    public partial class Provincias
    {
        public Provincias()
        {
            Localidades = new HashSet<Localidades>();
        }

        public long IdProvincia { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<Localidades> Localidades { get; set; }
    }
}
