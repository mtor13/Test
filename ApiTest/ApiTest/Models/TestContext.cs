using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ApiTest.Models;

public partial class TestContext : DbContext
{
    public TestContext()
    {
    }

    public TestContext(DbContextOptions<TestContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Actividades> Actividades { get; set; }

    public virtual DbSet<Paises> Paises { get; set; }

    public virtual DbSet<Usuarios> Usuarios { get; set; }

//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-GBJJSG8\\TEST;Initial Catalog=Test; User Id=SA;Password=test;Trusted_Connection=True;TrustServerCertificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Actividades>(entity =>
        {
            entity.HasKey(e => e.IdActividad);

            entity.Property(e => e.IdActividad).HasColumnName("id_actividad");
            entity.Property(e => e.Actividad)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("actividad");
            entity.Property(e => e.CreateDate).HasColumnName("create_date");
            entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");
        });

        modelBuilder.Entity<Paises>(entity =>
        {
            entity.HasKey(e => e.Codigo).HasName("PK_Paises");

            entity.Property(e => e.Codigo)
                .HasMaxLength(3)
                .HasColumnName("codigo");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<Usuarios>(entity =>
        {
            entity.HasKey(e => e.IdUsuario);

            entity.Property(e => e.IdUsuario).HasColumnName("Id_Usuario");
            entity.Property(e => e.Apellido).HasMaxLength(50);
            entity.Property(e => e.CorreoElectronico)
                .HasMaxLength(50)
                .HasColumnName("Correo_Electronico");
            entity.Property(e => e.FechaNacimiento).HasColumnName("Fecha_Nacimiento");
            entity.Property(e => e.Nombre).HasMaxLength(50);
            entity.Property(e => e.PaisResidencia)
                .HasMaxLength(3)
                .HasColumnName("Pais_Residencia");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
