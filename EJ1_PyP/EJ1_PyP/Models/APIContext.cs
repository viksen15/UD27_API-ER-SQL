using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EJ1_PyP.Models
{
    public class APIContext : DbContext
    {
        public APIContext(DbContextOptions<APIContext> options)
            : base(options)
        { }

        public virtual DbSet<Piezas> Piezas { get; set; }
        public virtual DbSet<Proveedores> Proveedores { get; set; }
        public virtual DbSet<Suministra> Suministra { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<Piezas>(entity =>
            {
                entity.ToTable("Piezas");
                entity.HasKey(e => e.Codigo);
                entity.Property(e => e.Codigo).UseIdentityColumn();
                entity.Property(e => e.Nombre).HasMaxLength(100);
            });

            modelBuilder.Entity<Proveedores>(entity =>
            {
                entity.ToTable("Proveedores");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).HasMaxLength(4);
                entity.Property(e => e.Nombre).HasMaxLength(100);
            });

            modelBuilder.Entity<Suministra>(entity =>
            {
                entity.ToTable("Suministra");
                entity.HasKey(e => e.CodigoPieza);
                entity.HasKey(e => e.IdProveedor);

                entity.HasOne(d => d.Piezas)
                .WithMany(d => d.Suministra)
                .HasForeignKey(d => d.CodigoPieza)
                .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(p => p.Proveedores)
                .WithMany(p => p.Suministra)
                .HasForeignKey(p => p.IdProveedor)
                .OnDelete(DeleteBehavior.ClientSetNull);
                
            });
        }
    }
}
