using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CMRmvc.ViewModel
{
    public class LoginViewModel
    {
        [StringLength(50)]
        [DisplayName("Nombre de usuario")]
        [Required(ErrorMessage = "Debe completar el nombre de usuario.")]
        public string UserName { get; set; }
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Debe completar la contraseña.")]
        [DisplayName("Contraseña")]
        public string PasswordHash { get; set; }
    }
}
