using System;
using System.Collections.Generic;
using System.Text;
using CMRmvc.Models;
using CRMmvc.Helpers;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace CMRmvc.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        //public virtual DbSet<User> Users{ get; set; }    
        public virtual DbSet<Parametros> Parametros { get; set; }
        public virtual DbSet<ParametrosTipo> ParametrosTipo { get; set; }

        private readonly IOptions<ConnectionsStrings> connectionStrings;
        public ApplicationDbContext(IOptions<ConnectionsStrings> connectionString)
        {
            connectionStrings = connectionString;
        }
        private readonly DbContextOptions<ApplicationDbContext> options;
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IOptions<ConnectionsStrings> connectionString) : base(options)
        {
            connectionStrings = connectionString;
            this.options = options;
        }
        public DbSet<CMRmvc.Models.User> User { get; set; }
    }
}
