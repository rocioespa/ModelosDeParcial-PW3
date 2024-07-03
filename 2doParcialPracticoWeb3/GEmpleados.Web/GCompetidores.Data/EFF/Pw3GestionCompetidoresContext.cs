using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace GCompetidores.Web.EFF
{
    public partial class Pw3GestionCompetidoresContext : DbContext
    {
        public Pw3GestionCompetidoresContext()
        {
        }

        public Pw3GestionCompetidoresContext(DbContextOptions<Pw3GestionCompetidoresContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Competidor> Competidors { get; set; } = null!;
        public virtual DbSet<Deporte> Deportes { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-1S9GKAA;Database=Pw3- GestionCompetidores;Trusted_Connection=True; Encrypt=false");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Competidor>(entity =>
            {
                entity.HasKey(e => e.IdCompetidor);

                entity.ToTable("Competidor");

                entity.Property(e => e.NombreCompetidor).HasMaxLength(50);

                entity.HasOne(d => d.IdDeporteNavigation)
                    .WithMany(p => p.Competidors)
                    .HasForeignKey(d => d.IdDeporte)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Competidor_Deporte");
            });

            modelBuilder.Entity<Deporte>(entity =>
            {
                entity.HasKey(e => e.IdDeporte);

                entity.ToTable("Deporte");

                entity.Property(e => e.NombreDeporte).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
