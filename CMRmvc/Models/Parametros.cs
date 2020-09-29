using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CMRmvc.Models
{
    public partial class Parametros
    {
        public long IdParametro { get; set; }
        [Required(ErrorMessage = "Debe seleccionar un tipo de parámetro.")]
        [DisplayName("Tipo")]
        public long IdParametroTipo { get; set; }
        [DisplayName("Clave")]
        public string ParClave { get; set; }
        [DisplayName("Nombre")]
        public string ParNombre { get; set; }
        [DisplayName("Valor")]
        public string ParValor { get; set; }
        [Required(ErrorMessage = "Debe seleccionar un tipo de dato.")]
        [DisplayName("Tipo Dato")]
        public short ParTipo { get; set; }
        [Required(ErrorMessage = "Debe seleccionar Admin.")]
        [DisplayName("Admin")]
        public short ParAdmin { get; set; }
        public DateTime? FecIns { get; set; }
        public DateTime? FecUpd { get; set; }
        public DateTime? FecDel { get; set; }
        public string UsrIns { get; set; }
        public string UsrUpd { get; set; }
        public string UsrDel { get; set; }

        public virtual ParametrosTipo IdParametroTipoNavigation { get; set; }
    }
}
