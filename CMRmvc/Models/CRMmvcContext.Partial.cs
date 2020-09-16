using CRMmvc.Helpers;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMRmvc.Models
{
    public partial class CRMmvcContext : IdentityDbContext<User, Role, long, IdentityUserClaim<long>, IdentityUserRole<long>, IdentityUserLogin<long>, IdentityRoleClaim<long>, IdentityUserToken<long>>
    {
        private readonly IOptions<ConnectionsStrings> connectionStrings;
        public CRMmvcContext(IOptions<ConnectionsStrings> connectionString)
        {
            connectionStrings = connectionString;
        }
        private readonly DbContextOptions<CRMmvcContext> options;
        public CRMmvcContext(DbContextOptions<CRMmvcContext> options, IOptions<ConnectionsStrings> connectionString) : base(options)
        {
            connectionStrings = connectionString;
            this.options = options;
        }
    }
}


/*
 * 1- Agregar la tablas que sean necesario incluir en el contexto
 * 2- Correr el siguiente comando con las tablas actualizadas en la consola de nuget
Scaffold-DbContext "Server=localhost;Initial Catalog=CRMmvc;User ID=sa;Password=asd123;application name=CRM;MultipleActiveResultSets=True" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models -Tables "dbo.Parametros", "dbo.ParametrosTipo" -Force
    3-Luego de correr el comando ir a la clase CRMmvcContext para:
        a- quitar la herencia de DbContext
        b- cambiar el connection string en OnConfiguring por: connectionStrings.Value.DefaultConnection
*/
