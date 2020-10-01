using CMRmvc.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CMRmvc.ViewModel
{
    public class ParametrosViewModel
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
        public bool ParAdmin { get; set; }
        public DateTime? FecIns { get; set; }
        public DateTime? FecUpd { get; set; }
        public DateTime? FecDel { get; set; }
        public string UsrIns { get; set; }
        public string UsrUpd { get; set; }
        public string UsrDel { get; set; }

        public virtual ParametrosTipo IdParametroTipoNavigation { get; set; }

    }

    public class ParametrosTipoViewModel
    {
        public ParametrosTipoViewModel()
        {
            Parametros = new HashSet<ParametrosViewModel>();
        }

        public long IdParametroTipo { get; set; }
        public string TipNombre { get; set; }
        public string TipDescripcion { get; set; }
        public bool? TipVisible { get; set; }
        public bool TipAdmin { get; set; }
        public DateTime? FecIns { get; set; }
        public DateTime? FecUpd { get; set; }
        public DateTime? FecDel { get; set; }
        public string UsrIns { get; set; }
        public string UsrUpd { get; set; }
        public string UsrDel { get; set; }

        public ICollection<ParametrosViewModel> Parametros { get; set; }
    }
}
