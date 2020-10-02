using CMRmvc.Models;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CMRmvc.ViewModel
{
    public class RoleViewModel : IdentityRole<long>
    {
        public RoleViewModel()
        {
            RolesAcciones = new List<RolesAccionesViewModel>();
            Menu = new List<MenuItemPadreViewModel>();
            PerfilMenuHijo = new List<PerfilMenuHijoViewModel>();
        }

        [StringLength(50)]
        [Required(ErrorMessage = "Debe completar el nombre del rol")]
        [DisplayName("Nombre")]
        public override string Name { get; set; }
        [DisplayName("Activo")]
        public bool IsActive { get; set; }
        public List<MenuItemPadreViewModel> Menu { get; set; }
        public List<RolesAccionesViewModel> RolesAcciones { get; set; }
        public List<PerfilMenuHijoViewModel> PerfilMenuHijo { get; set; }

    }
}
