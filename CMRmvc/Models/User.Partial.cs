using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CMRmvc.Models
{
    public partial class User : IdentityUser<long>
    {
        [Key]
        public override long Id { get; set; }
        [StringLength(50)]
        [DisplayName("Nombre de usuario")]
        [Required(ErrorMessage = "Debe completar el nombre de usuario.")]
        public override string UserName { get; set; }
        [StringLength(200)]
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Debe completar el email.")]
        public override string Email { get; set; }
        [StringLength(50)]
        [DataType(DataType.PhoneNumber)]
        [DisplayName("Telefono")]

        [Required(ErrorMessage = "Debe completar el número de teléfono.")]
        public override string PhoneNumber { get; set; }
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Debe completar la contraseña.")]
        [DisplayName("Contraseña")]
        public override string PasswordHash { get; set; }
        [StringLength(100)]
        [DisplayName("Nombre")]
        [Required(ErrorMessage = "Debe completar el nombre.")]
        public string NombreCompleto { get; set; }
        [StringLength(15)]
        [DisplayName("Dni")]
        [Required(ErrorMessage = "Debe completar el documento.")]
        public string Dni { get; set; }
        [StringLength(5000)]
        [DisplayName("Foto")]
        public string Imagen { get; set; }
        [DisplayName("Activo")]
        public bool Activo { get; set; }
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
        [DisplayName("Perfil")]
        public long RoleID { get; set; }
        [DisplayName("Perfil")]
        public virtual Role Role { get; set; }
        
        public override string ToString()
        {
            return string.Format("Id: {0}, UserName: {1},Email: {2},PhoneNumber: {3},NombreCompleto: {4},Dni: {5},Activo: {6}"
                    , Id, UserName, Email, PhoneNumber, NombreCompleto, Dni, Activo);
        }
    }
}
