using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CMRmvc.ViewModel
{
    public class ClienteViewModel
    {
        public long IdCliente { get; set; }
        [DisplayName("Tipo Documento")]
        //[Required(ErrorMessage = "Debe seleccionar un tipo de documento.")]
        [Range(1, Int16.MaxValue, ErrorMessage = "Debe seleccionar un tipo de documento.")]
        public long IdDocumentoTipo { get; set; }
        [DisplayName("Documento")]
        [Required(ErrorMessage = "Debe completar el número de documento.")]
        public string NroDocumento { get; set; }
        [DisplayName("Nombre de usuario")]
        [Required(ErrorMessage = "Debe completar el nombre de usuario.")]
        public string NombreUsuario { get; set; }
        [DisplayName("Contraseña")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Debe ingresar una contraseña.")]
        public string Clave { get; set; }
        [DisplayName("Nombre")]
        [Required(ErrorMessage = "Debe completar su nombre.")]
        public string Nombre { get; set; }
        [DisplayName("Apellido")]
        [Required(ErrorMessage = "Debe completar su apellido.")]
        public string Apellido { get; set; }
        [DisplayName("Email")]
        [Required(ErrorMessage = "Debe ingresar un email.")]
        [DataType(DataType.EmailAddress)]
        public string Mail { get; set; }
        public DateTime? FecUltimoLogin { get; set; }
        [DisplayName("Activo")]
        public bool Activo { get; set; }
        [DisplayName("Teléfono")]
        [DataType(DataType.PhoneNumber)]
        public string Telefono { get; set; }
        [DisplayName("Localidad")]
      //  [Required(ErrorMessage = "Debe seleccionar una localidad.")]
        [Range(1, long.MaxValue, ErrorMessage = "Debe seleccionar una localidad.")]
        public long IdLocalidad { get; set; }
        [DisplayName("Dirección")]
        public string Direccion { get; set; }
        //[Required(ErrorMessage = "Debe seleccionar el género.")]
        [Range(1, Int16.MaxValue, ErrorMessage = "Debe seleccionar un género.")]
        [DisplayName("Género")]
        public int Sexo { get; set; }
        public DateTime? FecIns { get; set; }
        public DateTime? FecUpd { get; set; }
        public DateTime? FecDel { get; set; }
        public string UsrIns { get; set; }
        public string UsrUpd { get; set; }
        public string UsrDel { get; set; }
      //  [Required(ErrorMessage = "Debe seleccionar una provincia.")]
        [Range(1, long.MaxValue, ErrorMessage = "Debe seleccionar una provincia.")]
        public long IdProvincia { get; set; }
    }
}
