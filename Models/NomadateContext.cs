using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace nomadate_web.Models;

public partial class NomadateContext : DbContext
{
    public NomadateContext()
    {
    }

    public NomadateContext(DbContextOptions<NomadateContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Habitacion> Habitacions { get; set; }

    public virtual DbSet<Resenna> Resennas { get; set; }

    public virtual DbSet<Reservacion> Reservacions { get; set; }

    public virtual DbSet<ReservacionDetalle> ReservacionDetalles { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

   // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
  //      => optionsBuilder.UseSqlServer("Server=localhost,1433;Database=nomadate;User Id=sa;Password=Sql2022@Strong;TrustServerCertificate=True;");



    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Habitacion>(entity =>
        {
            entity.HasKey(e => e.IdHabitacion).HasName("PK__Habitaci__6B8A72E28CF7064C");

            entity.ToTable("Habitacion");

            entity.HasIndex(e => e.NumeroHabitacion, "UQ__Habitaci__778CE121D68EF7C6").IsUnique();

            entity.Property(e => e.IdHabitacion).HasColumnName("Id_Habitacion");
            entity.Property(e => e.Descripcion).HasMaxLength(500);
            entity.Property(e => e.NumeroHabitacion)
                .HasMaxLength(20)
                .HasColumnName("Numero_Habitacion");
            entity.Property(e => e.Precio).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.RutaImagen)
                .HasMaxLength(300)
                .HasColumnName("Ruta_Imagen");
            entity.Property(e => e.TieneAire).HasColumnName("Tiene_Aire");
            entity.Property(e => e.TieneTv).HasColumnName("Tiene_TV");
        });

        modelBuilder.Entity<Resenna>(entity =>
        {
            entity.HasKey(e => e.IdResenna).HasName("PK__Resenna__9F850A2DCEB1BF9E");

            entity.ToTable("Resenna");

            entity.HasIndex(e => e.IdHabitacion, "IX_Resenna_Habitacion");

            entity.HasIndex(e => e.IdUsuario, "IX_Resenna_Usuario");

            entity.Property(e => e.IdResenna).HasColumnName("Id_Resenna");
            entity.Property(e => e.Comentario).HasMaxLength(500);
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(sysutcdatetime())")
                .HasColumnName("Fecha_Creacion");
            entity.Property(e => e.IdHabitacion).HasColumnName("Id_Habitacion");
            entity.Property(e => e.IdUsuario).HasColumnName("Id_Usuario");

            entity.HasOne(d => d.IdHabitacionNavigation).WithMany(p => p.Resennas)
                .HasForeignKey(d => d.IdHabitacion)
                .HasConstraintName("FK_Resenna_Habitacion");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Resennas)
                .HasForeignKey(d => d.IdUsuario)
                .HasConstraintName("FK_Resenna_Usuario");
        });

        modelBuilder.Entity<Reservacion>(entity =>
        {
            entity.HasKey(e => e.IdReservacion).HasName("PK__Reservac__DBAF7A9E58D043FD");

            entity.ToTable("Reservacion");

            entity.HasIndex(e => e.IdHabitacion, "IX_Reservacion_Habitacion");

            entity.HasIndex(e => e.IdUsuario, "IX_Reservacion_Usuario");

            entity.Property(e => e.IdReservacion).HasColumnName("Id_Reservacion");
            entity.Property(e => e.Estado)
                .HasMaxLength(20)
                .HasDefaultValue("vigente");
            entity.Property(e => e.IdHabitacion).HasColumnName("Id_Habitacion");
            entity.Property(e => e.IdUsuario).HasColumnName("Id_Usuario");

            entity.HasOne(d => d.IdHabitacionNavigation).WithMany(p => p.Reservacions)
                .HasForeignKey(d => d.IdHabitacion)
                .HasConstraintName("FK_Reservacion_Habitacion");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Reservacions)
                .HasForeignKey(d => d.IdUsuario)
                .HasConstraintName("FK_Reservacion_Usuario");
        });

        modelBuilder.Entity<ReservacionDetalle>(entity =>
        {
            entity.HasKey(e => e.IdReservacionDetalle).HasName("PK__Reservac__26F9E789CCDB71DB");

            entity.ToTable("Reservacion_Detalle");

            entity.HasIndex(e => e.IdReservacion, "IX_Reservacion_Detalle_Reservacion");

            entity.Property(e => e.IdReservacionDetalle).HasColumnName("Id_Reservacion_Detalle");
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(sysutcdatetime())")
                .HasColumnName("Fecha_Creacion");
            entity.Property(e => e.IdReservacion).HasColumnName("Id_Reservacion");
            entity.Property(e => e.Precio).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.IdReservacionNavigation).WithMany(p => p.ReservacionDetalles)
                .HasForeignKey(d => d.IdReservacion)
                .HasConstraintName("FK_Reservacion_Detalle_Reservacion");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.IdUsuario).HasName("PK__Usuario__63C76BE251BE3DD1");

            entity.ToTable("Usuario");

            entity.HasIndex(e => e.Email, "UQ__Usuario__A9D10534BA2199A6").IsUnique();

            entity.Property(e => e.IdUsuario).HasColumnName("Id_Usuario");
            entity.Property(e => e.Apellido).HasMaxLength(100);
            entity.Property(e => e.Contrasenna).HasMaxLength(255);
            entity.Property(e => e.Email).HasMaxLength(200);
            entity.Property(e => e.Nombre).HasMaxLength(100);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
