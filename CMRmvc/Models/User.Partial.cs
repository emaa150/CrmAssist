using Microsoft.AspNetCore.Identity;
using Microsoft.Data.SqlClient.Server;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CMRmvc.Models
{
    public partial class User : IdentityUser<long>
    {
        [Key]
        public override long Id { get; set; }
        [StringLength(50)]
        [Required(ErrorMessage = "Debe completar el UserName.")]
        public override string UserName { get; set; }
        [StringLength(200)]
        public override string Email { get; set; }
        [StringLength(50)]
        public override string PhoneNumber { get; set; }
        [DataType(DataType.Password)]
        [Required(ErrorMessage ="Debe completar la contraseña.")]
        public override string PasswordHash { get; set; }
        [StringLength(100)]
        public string NombreCompleto { get; set; }
        [StringLength(15)]
        public string Dni { get; set; }
        [StringLength(500)]
        public string Imagen { get; set; }        
        public bool? Activo { get; set; }
        public DateTime? FecUltIngreso { get; set; }
        public DateTime? FecClaveVcto { get; set; }
        public int NroLoginNok { get; set; }
        public DateTime? FecIns { get; set; }
        public DateTime? FecUpd { get; set; }
        public DateTime? FecDel { get; set; }
        [StringLength(100)]
        public string UsrIns { get; set; }
        [StringLength(100)]
        public string UsrUpd { get; set; }
        [StringLength(100)]
        public string UsrDel { get; set; }
        [Display(Name = "Recordarme")]
        public bool RememberMe { get; set; }

    }
}
