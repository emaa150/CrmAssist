using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CMRmvc.Models
{
    public partial class CRMContext 
    {
        public CRMContext()
        {
        }

        public CRMContext(DbContextOptions<CRMContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Clientes> Clientes { get; set; }
        public virtual DbSet<DocumentoTipo> DocumentoTipo { get; set; }
        public virtual DbSet<Localidades> Localidades { get; set; }
        public virtual DbSet<MenuHijoAcciones> MenuHijoAcciones { get; set; }
        public virtual DbSet<MenuItemHijo> MenuItemHijo { get; set; }
        public virtual DbSet<MenuItemPadre> MenuItemPadre { get; set; }
        public virtual DbSet<Parametros> Parametros { get; set; }
        public virtual DbSet<ParametrosTipo> ParametrosTipo { get; set; }
        public virtual DbSet<PerfilMenuHijo> PerfilMenuHijo { get; set; }
        public virtual DbSet<Provincias> Provincias { get; set; }
        public virtual DbSet<RolesAcciones> RolesAcciones { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(connectionStrings.Value.DefaultConnection);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Clientes>(entity =>
            {
                entity.HasKey(e => e.IdCliente)
                    .HasName("PK__Clientes__885457EE8F021A97");

                entity.Property(e => e.IdCliente).HasColumnName("idCliente");

                entity.Property(e => e.Apellido)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Clave)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Direccion)
                    .HasMaxLength(220)
                    .IsUnicode(false);

                entity.Property(e => e.FecDel)
                    .HasColumnName("FecDEL")
                    .HasColumnType("datetime");

                entity.Property(e => e.FecIns)
                    .HasColumnName("FecINS")
                    .HasColumnType("datetime");

                entity.Property(e => e.FecUltimoLogin).HasColumnType("datetime");

                entity.Property(e => e.FecUpd)
                    .HasColumnName("FecUPD")
                    .HasColumnType("datetime");

                entity.Property(e => e.Foto)
                    .HasMaxLength(8000)
                    .IsUnicode(false);

                entity.Property(e => e.IdDocumentoTipo).HasColumnName("idDocumentoTipo");

                entity.Property(e => e.Mail)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NombreUsuario)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NroDocumento)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Telefono)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UsrDel)
                    .HasColumnName("UsrDEL")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.UsrIns)
                    .HasColumnName("UsrINS")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.UsrUpd)
                    .HasColumnName("UsrUPD")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdDocumentoTipoNavigation)
                    .WithMany(p => p.Clientes)
                    .HasForeignKey(d => d.IdDocumentoTipo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Clientes_DocumentoTipo_FK");

                entity.HasOne(d => d.IdLocalidadNavigation)
                    .WithMany(p => p.Clientes)
                    .HasForeignKey(d => d.IdLocalidad)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Cliente_Localidades_FK");
            });

            modelBuilder.Entity<DocumentoTipo>(entity =>
            {
                entity.HasKey(e => e.IdDocTipo)
                    .HasName("PK__Document__CF0ADB7CDF482392");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Localidades>(entity =>
            {
                entity.HasKey(e => e.IdLocalidad)
                    .HasName("PK__Localida__274326129999B75C");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdProvinciaNavigation)
                    .WithMany(p => p.Localidades)
                    .HasForeignKey(d => d.IdProvincia)
                    .HasConstraintName("Localidades_Provincia_FK");
            });

            modelBuilder.Entity<MenuHijoAcciones>(entity =>
            {
                entity.HasKey(e => e.IdMenuHijoAccion)
                    .HasName("PK__MenuHijo__CB9BC911C217FB02");

                entity.Property(e => e.MhaClase)
                    .HasColumnName("mhaClase")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.MhaIcono)
                    .HasColumnName("mhaIcono")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.MhaKey)
                    .HasColumnName("mhaKey")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.MhaNewTab).HasColumnName("mhaNewTab");

                entity.Property(e => e.MhaOrden).HasColumnName("mhaOrden");

                entity.Property(e => e.MhaTexto)
                    .HasColumnName("mhaTexto")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.MhaTooltip)
                    .HasColumnName("mhaTooltip")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.MhaUrl)
                    .HasColumnName("mhaURL")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdMenuHijoNavigation)
                    .WithMany(p => p.MenuHijoAcciones)
                    .HasForeignKey(d => d.IdMenuHijo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("MenuAcciones_MenuHijo_FK");
            });

            modelBuilder.Entity<MenuItemHijo>(entity =>
            {
                entity.HasKey(e => e.IdMenuHijo)
                    .HasName("PK__MenuItem__E5A0389D88729454");

                entity.Property(e => e.Icono).HasMaxLength(50);

                entity.HasOne(d => d.IdMenuPadreNavigation)
                    .WithMany(p => p.MenuItemHijo)
                    .HasForeignKey(d => d.IdMenuPadre)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("MenuPadre_MenuHijo_FK");
            });

            modelBuilder.Entity<MenuItemPadre>(entity =>
            {
                entity.HasKey(e => e.IdMenuPadre)
                    .HasName("PK__MenuItem__2C1D57B55FAE039B");

                entity.Property(e => e.Icono).HasMaxLength(50);

                entity.Property(e => e.Nombre).HasMaxLength(50);
            });

            modelBuilder.Entity<Parametros>(entity =>
            {
                entity.HasKey(e => e.IdParametro)
                    .HasName("PK__Parametr__9C816E5F89DA85D0");

                entity.Property(e => e.IdParametro).HasColumnName("idParametro");

                entity.Property(e => e.FecDel)
                    .HasColumnName("FecDEL")
                    .HasColumnType("datetime");

                entity.Property(e => e.FecIns)
                    .HasColumnName("FecINS")
                    .HasColumnType("datetime");

                entity.Property(e => e.FecUpd)
                    .HasColumnName("FecUPD")
                    .HasColumnType("datetime");

                entity.Property(e => e.IdParametroTipo).HasColumnName("idParametroTipo");

                entity.Property(e => e.ParAdmin).HasColumnName("parAdmin");

                entity.Property(e => e.ParClave)
                    .IsRequired()
                    .HasColumnName("parClave")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ParNombre)
                    .IsRequired()
                    .HasColumnName("parNombre")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ParTipo).HasColumnName("parTipo");

                entity.Property(e => e.ParValor)
                    .IsRequired()
                    .HasColumnName("parValor")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.UsrDel)
                    .HasColumnName("UsrDEL")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.UsrIns)
                    .HasColumnName("UsrINS")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.UsrUpd)
                    .HasColumnName("UsrUPD")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdParametroTipoNavigation)
                    .WithMany(p => p.Parametros)
                    .HasForeignKey(d => d.IdParametroTipo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Parametros_ParametroTipo_FK");
            });

            modelBuilder.Entity<ParametrosTipo>(entity =>
            {
                entity.HasKey(e => e.IdParametroTipo)
                    .HasName("PK__Parametr__A8D83328843AB2AC");

                entity.Property(e => e.IdParametroTipo).HasColumnName("idParametroTipo");

                entity.Property(e => e.TipAdmin).HasColumnName("tipAdmin");

                entity.Property(e => e.TipDescripcion)
                    .HasColumnName("tipDescripcion")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.TipNombre)
                    .IsRequired()
                    .HasColumnName("tipNombre")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.TipVisible)
                    .HasColumnName("tipVisible")
                    .HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<PerfilMenuHijo>(entity =>
            {
                entity.HasKey(e => e.IdPerfilMenuHijo)
                    .HasName("PK__PerfilMe__9043AF82B0D81B66");

                entity.HasOne(d => d.IdMenuHijoNavigation)
                    .WithMany(p => p.PerfilMenuHijo)
                    .HasForeignKey(d => d.IdMenuHijo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("MenuItemHijo_PerfilMenuHijo_FK");
            });

            modelBuilder.Entity<Provincias>(entity =>
            {
                entity.HasKey(e => e.IdProvincia)
                    .HasName("PK__Provinci__EED744550FF5BB36");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<RolesAcciones>(entity =>
            {
                entity.HasKey(e => e.IdPerfilAccion)
                    .HasName("PK__RolesAcc__56ADAC70D8C3C5BA");

                entity.HasOne(d => d.IdMenuHijoAccionNavigation)
                    .WithMany(p => p.RolesAcciones)
                    .HasForeignKey(d => d.IdMenuHijoAccion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("MenuAcciones_RolesAcciones_FK");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
