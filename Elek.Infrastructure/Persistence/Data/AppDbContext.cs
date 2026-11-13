using System;
using System.Collections.Generic;
using Elek.Infrastructure.Persistence.Entities;
using Microsoft.EntityFrameworkCore;

namespace Elek.Infrastructure.Persistence.Data;

public partial class AppDbContext : DbContext
{
    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Alumno> Alumnos { get; set; }

    public virtual DbSet<AlumnosXprofesore> AlumnosXprofesores { get; set; }

    public virtual DbSet<Escuela> Escuelas { get; set; }

    public virtual DbSet<Profesore> Profesores { get; set; }

//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseSqlServer("Server=.;Database=Elektra;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Alumno>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Alumnos__3214EC0731485ED8");

            entity.Property(e => e.Uuid).HasDefaultValueSql("(newid())");

            entity.HasOne(d => d.IdEscuelaNavigation).WithMany(p => p.Alumnos)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Alumnos_Escuelas");
        });

        modelBuilder.Entity<AlumnosXprofesore>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__AlumnosX__3214EC071CFBF640");

            entity.HasOne(d => d.IdAlumnoNavigation).WithMany(p => p.AlumnosXprofesores)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AlumnosXProfesores_Alumnos");

            entity.HasOne(d => d.IdProfesorNavigation).WithMany(p => p.AlumnosXprofesores)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AlumnosXProfesores_Profesores");
        });

        modelBuilder.Entity<Escuela>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Escuelas__3214EC077C3892FD");

            entity.Property(e => e.Uuid).HasDefaultValueSql("(newid())");
        });

        modelBuilder.Entity<Profesore>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Profesor__3214EC07C791932C");

            entity.Property(e => e.Uuid).HasDefaultValueSql("(newid())");

            entity.HasOne(d => d.IdEscuelaNavigation).WithMany(p => p.Profesores)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Profesores_Escuelas");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
