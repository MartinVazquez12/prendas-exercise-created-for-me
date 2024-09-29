using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace prendasWebApi.Models;

public partial class PrendasDbContext : DbContext
{
    public PrendasDbContext()
    {
    }

    public PrendasDbContext(DbContextOptions<PrendasDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Marca> Marcas { get; set; }

    public virtual DbSet<Prenda> Prendas { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=prendasDB");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Marca>(entity =>
        {
            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.Marca1)
                .HasMaxLength(100)
                .HasColumnName("Marca");
        });

        modelBuilder.Entity<Prenda>(entity =>
        {
            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.Color).HasMaxLength(50);
            entity.Property(e => e.IdMarca).HasColumnName("Id_Marca");
            entity.Property(e => e.Nombre).HasMaxLength(100);
            entity.Property(e => e.Talle).HasMaxLength(50);

            entity.HasOne(d => d.IdMarcaNavigation).WithMany(p => p.Prenda)
                .HasForeignKey(d => d.IdMarca)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Prendas_Marcas");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
