using CMRmvc.Models;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CMRmvc.ViewModel
{
    public class RoleViewModel : IdentityRole<long>
    {

        [StringLength(50)]
        [Required(ErrorMessage = "Debe completar el nombre del rol")]
        [DisplayName("Nombre")]
        public override string Name { get; set; }
        [DisplayName("Activo")]
        public bool IsActive { get; set; }
        public List<MenuItemPadre> Menu { get; set; }
        public List<RolesAcciones> RolesAcciones { get; set; }
        public List<PerfilMenuHijo> PerfilMenuHijo { get; set; }

    }
}
