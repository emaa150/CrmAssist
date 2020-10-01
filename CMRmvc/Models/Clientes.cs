using System;
using System.Collections.Generic;

namespace CMRmvc.Models
{
    public partial class Clientes
    {
        public long IdCliente { get; set; }
        public long IdDocumentoTipo { get; set; }
        public string NroDocumento { get; set; }
        public string NombreUsuario { get; set; }
        public string Clave { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Mail { get; set; }
        public DateTime? FecUltimoLogin { get; set; }
        public bool Activo { get; set; }
        public string Telefono { get; set; }
        public long IdLocalidad { get; set; }
        public string Direccion { get; set; }
        public int Sexo { get; set; }
        public DateTime? FecIns { get; set; }
        public DateTime? FecUpd { get; set; }
        public DateTime? FecDel { get; set; }
        public string UsrIns { get; set; }
        public string UsrUpd { get; set; }
        public string UsrDel { get; set; }

        public virtual DocumentoTipo IdDocumentoTipoNavigation { get; set; }
        public virtual Localidades IdLocalidadNavigation { get; set; }
    }
}
