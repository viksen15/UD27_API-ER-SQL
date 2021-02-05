using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace EJ2_C.Models
{
    public class APIContext : DbContext
    {
        public APIContext(DbContextOptions<APIContext> options)
            : base(options)
        { }

        public virtual DbSet<Cientificos> Cientificos { get; set; }
        public virtual DbSet<Proyectos> Proyectos { get; set; }
        public virtual DbSet<Asignado_A> Asignado_A { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cientificos>(entity =>
            {
                entity.ToTable("Cientificos");
                entity.HasKey(e => e.DNI);
                entity.Property(e => e.DNI).HasMaxLength(8);
                entity.Property(e => e.NomApels).HasMaxLength(255);
            });

            modelBuilder.Entity<Proyectos>(entity =>
            {
                entity.ToTable("Proyecto");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).HasMaxLength(4);
                entity.Property(e => e.Nombre).HasMaxLength(255);
            });

            modelBuilder.Entity<Asignado_A>(entity =>
            {
                entity.ToTable("Asignado_A");

                entity.HasKey(d => d.Cientifico);
                entity.Property(d => d.Cientifico).HasMaxLength(8);
                entity.HasOne(d => d.Cientificos)
                .WithMany(d => d.Asignado_A)
                .HasForeignKey(d => d.Cientifico)
                .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasKey(p => p.Proyecto);
                entity.Property(p => p.Proyecto).HasMaxLength(4);
                entity.HasOne(p => p.Proyectos)
                .WithMany(p => p.Asignado_A)
                .HasForeignKey(p => p.Proyecto)
                .OnDelete(DeleteBehavior.ClientSetNull);
            });
        }
    }
}
