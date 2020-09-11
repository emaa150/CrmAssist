using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CMRmvc.Models
{
    public class User
    {
        
        [Key]
        public long IdUsuario { get; set; }
        public long IdPerfil { get; set; }
        [Required(ErrorMessage = "Debe ingresar el nombre de usuario.")]
        [Display(Name = "User Name")]
        public string UsrLogin { get; set; }
        [Required(ErrorMessage = "Debe ingresar la contraseña.")]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string UsrClave { get; set; }
        public string UsrNombreCompleto { get; set; }
        public string UsrDni { get; set; }
        public string UsrTelefono { get; set; }
        public string UsrImagen { get; set; }
        public string UsrCorreo { get; set; }
        public bool? UsrActivo { get; set; }
        public DateTime? UsrFecUltIngreso { get; set; }
        public DateTime? UsrFecClaveVcto { get; set; }
        public int UsrNroLoginNok { get; set; }
        public DateTime? FecIns { get; set; }
        public DateTime? FecUpd { get; set; }
        public DateTime? FecDel { get; set; }
        public string UsrIns { get; set; }
        public string UsrUpd { get; set; }
        public string UsrDel { get; set; }
        [Display(Name = "Recordarme")]
        public bool usrRememberMe { get; set; }
    }
}
