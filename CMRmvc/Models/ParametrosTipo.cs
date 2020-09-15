using System;
using System.Collections.Generic;

namespace CMRmvc.Models
{
    public partial class ParametrosTipo
    {
        public ParametrosTipo()
        {
            Parametros = new HashSet<Parametros>();
        }

        public long IdParametroTipo { get; set; }
        public string TipNombre { get; set; }
        public string TipDescripcion { get; set; }
        public bool? TipVisible { get; set; }
        public bool TipAdmin { get; set; }

        public virtual ICollection<Parametros> Parametros { get; set; }
    }
}
