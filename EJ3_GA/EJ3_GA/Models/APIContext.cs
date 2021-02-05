using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace EJ3_GA.Models
{
    public class APIContext : DbContext
    {
        public APIContext(DbContextOptions<APIContext> options)
            : base(options)
        { }

        public virtual DbSet<Cajeros> Cajeros { get; set; }
        public virtual DbSet<Productos> Productos { get; set; }
        public virtual DbSet<Maquinas_Registradoras> Maquinas_Registradoras { get; set; }
        public virtual DbSet<Venta> Venta { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cajeros>(entity =>
            {
                entity.ToTable("Cajeros");
                entity.HasKey(e => e.Codigo);
                entity.Property(e => e.Codigo).UseIdentityColumn();
                entity.Property(e => e.NomApels).HasMaxLength(255);
            });

            modelBuilder.Entity<Productos>(entity =>
            {
                entity.ToTable("Productos");
                entity.HasKey(e => e.Codigo);
                entity.Property(e => e.Codigo).UseIdentityColumn();
                entity.Property(e => e.Nombre).HasMaxLength(100);
            });

            modelBuilder.Entity<Maquinas_Registradoras>(entity =>
            {
                entity.ToTable("Maquinas_Registradoras");
                entity.HasKey(e => e.Codigo);
                entity.Property(e => e.Codigo).UseIdentityColumn();
            });

            modelBuilder.Entity<Venta>(entity =>
            {
                entity.ToTable("Venta");
                
                entity.HasKey(e => e.Cajero);
                entity.HasOne(e => e.Cajeros)
                .WithMany(e => e.Venta)
                .HasForeignKey(e => e.Cajero)
                .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasKey(b => b.Maquina);
                entity.HasOne(b => b.Maquinas_Registradoras)
                .WithMany(b => b.Venta)
                .HasForeignKey(b => b.Maquina)
                .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasKey(c => c.Producto);
                entity.HasOne(c => c.Productos)
                .WithMany(c => c.Venta)
                .HasForeignKey(c => c.Producto)
                .OnDelete(DeleteBehavior.ClientSetNull);
            });
        }
    }
}
