using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace EJ4_I.Models
{
    public class APIContext : DbContext
    {
        public APIContext(DbContextOptions<APIContext> options)
            : base(options)
        { }

        public virtual DbSet<Facultades> Facultades { get; set; }
        public virtual DbSet<Equipos> Equipos { get; set; }
        public virtual DbSet<Investigadores> Investigadores { get; set; }
        public virtual DbSet<Reserva> Reserva { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Facultades>(entity =>
            {
                entity.ToTable("Facultad");
                entity.HasKey(e => e.Codigo);
                entity.Property(e => e.Nombre).HasMaxLength(100);
            });

            modelBuilder.Entity<Equipos>(entity =>
            {
                entity.ToTable("Equipos");
                entity.HasKey(e => e.NumSerie);
                entity.Property(e => e.NumSerie).HasMaxLength(4);
                entity.Property(e => e.Nombre).HasMaxLength(100);
                entity.HasOne(e => e.Facultades)
                .WithMany(e => e.Equipos)
                .HasForeignKey(e => e.Facultad)
                .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Investigadores>(entity =>
            {
                entity.ToTable("Investigadores");
                entity.HasKey(e => e.DNI);
                entity.Property(e => e.DNI).HasMaxLength(8);
                entity.Property(e => e.NomApels).HasMaxLength(255);
                entity.HasOne(e => e.Facultades)
                .WithMany(e => e.Investigadores)
                .HasForeignKey(e => e.Facultad)
                .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Reserva>(entity =>
            {
                entity.ToTable("Reserva");

                entity.HasKey(e => e.DNI);
                entity.Property(e => e.DNI).HasMaxLength(8);
                entity.HasOne(e => e.Investigadores)
                .WithMany(e => e.Reserva)
                .HasForeignKey(e => e.DNI)
                .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasKey(b => b.NumSerie);
                entity.Property(b => b.NumSerie).HasMaxLength(4);
                entity.HasOne(b => b.Equipos)
                .WithMany(b => b.Reserva)
                .HasForeignKey(b => b.NumSerie)
                .OnDelete(DeleteBehavior.ClientSetNull);
            });
        }
    }
}
