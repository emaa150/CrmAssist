using Microsoft.AspNetCore.Identity;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CMRmvc.Models
{
    public partial class Role : IdentityRole<long>
    {
        [StringLength(50)]
        [Required(ErrorMessage = "Debe completar el nombre del rol")]
        [DisplayName("Nombre")]
        public override string Name { get; set; }
        [DisplayName("Activo")]
        public bool IsActive { get; set; }
    
    }
}
