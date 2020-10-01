using System;
using System.Collections.Generic;

namespace CMRmvc.Models
{
    public partial class DocumentoTipo
    {
        public DocumentoTipo()
        {
            Clientes = new HashSet<Clientes>();
        }

        public long IdDocTipo { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }

        public virtual ICollection<Clientes> Clientes { get; set; }
    }
}
