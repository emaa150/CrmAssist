using System;
using System.Collections.Generic;

namespace CMRmvc.Models
{
    public partial class Parametros
    {
        public long IdParametro { get; set; }
        public long IdParametroTipo { get; set; }
        public string ParClave { get; set; }
        public string ParNombre { get; set; }
        public string ParValor { get; set; }
        public short ParTipo { get; set; }
        public bool ParAdmin { get; set; }
        public DateTime? FecIns { get; set; }
        public DateTime? FecUpd { get; set; }
        public DateTime? FecDel { get; set; }
        public string UsrIns { get; set; }
        public string UsrUpd { get; set; }
        public string UsrDel { get; set; }

        public virtual ParametrosTipo IdParametroTipoNavigation { get; set; }
    }
}
