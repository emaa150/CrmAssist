using CRMmvc.Helpers;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace CMRmvc.Models
{
    public partial class CRMContext : IdentityDbContext<User, Role, long, IdentityUserClaim<long>, IdentityUserRole<long>, IdentityUserLogin<long>, IdentityRoleClaim<long>, IdentityUserToken<long>>
    {
        private readonly IOptions<ConnectionsStrings> connectionStrings;
        public CRMContext(IOptions<ConnectionsStrings> connectionString)
        {
            connectionStrings = connectionString;
        }
        private readonly DbContextOptions<CRMContext> options;
        public CRMContext(DbContextOptions<CRMContext> options, IOptions<ConnectionsStrings> connectionString) : base(options)
        {
            connectionStrings = connectionString;
            this.options = options;
        }
    }
}


/*
 * 1- Agregar la tablas que sean necesario incluir en el contexto
 * 2- Correr el siguiente comando con las tablas actualizadas en la consola de nuget
 * 
Scaffold-DbContext "Server=appti.assist.sa;Initial Catalog=CRM;User ID=CRMAdmin;Password=`$CRM123;application name=CRM;MultipleActiveResultSets=True" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models -Tables  "dbo.Parametros", "dbo.ParametrosTipo", "dbo.MenuItemPadre", "dbo.MenuItemHijo", "dbo.MenuHijoAcciones", "dbo.RolesAcciones", "dbo.PerfilMenuHijo" -Force
                    
    3-Luego de correr el comando ir a la clase CRMContext para:
        a- quitar la herencia de DbContext
        b- cambiar el connection string en OnConfiguring por: connectionStrings.Value.DefaultConnection
*/
