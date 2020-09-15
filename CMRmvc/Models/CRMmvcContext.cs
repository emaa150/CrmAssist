using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CMRmvc.Models
{
    public partial class CRMmvcContext
    {
        public CRMmvcContext()
        {
        }

        public CRMmvcContext(DbContextOptions<CRMmvcContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Parametros> Parametros { get; set; }
        public virtual DbSet<ParametrosTipo> ParametrosTipo { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer(connectionStrings.Value.DefaultConnection);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Parametros>(entity =>
            {
                entity.HasKey(e => e.IdParametro)
                    .HasName("PK__Parametr__9C816E5FADB882DF");

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
                    .HasName("PK__Parametr__A8D8332884BCF310");

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

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
