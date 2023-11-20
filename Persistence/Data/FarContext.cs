using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Domain.Entities;

namespace Persistence.Data;

public partial class FarContext : DbContext
{
    public FarContext()
    {
    }

    public FarContext(DbContextOptions<FarContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Contactopersona> Contactopersonas { get; set; }

    public virtual DbSet<Departamento> Departamentos { get; set; }

    public virtual DbSet<Detallemovinventario> Detallemovinventarios { get; set; }

    public virtual DbSet<Factura> Facturas { get; set; }

    public virtual DbSet<Formapago> Formapagos { get; set; }

    public virtual DbSet<Inventario> Inventarios { get; set; }

    public virtual DbSet<Marca> Marcas { get; set; }

    public virtual DbSet<Movimientoinventario> Movimientoinventarios { get; set; }

    public virtual DbSet<Pai> Pais { get; set; }

    public virtual DbSet<Persona> Personas { get; set; }

    public virtual DbSet<Presentacion> Presentacions { get; set; }

    public virtual DbSet<Producto> Productos { get; set; }

    public virtual DbSet<Rolpersona> Rolpersonas { get; set; }

    public virtual DbSet<Tipocontacto> Tipocontactos { get; set; }

    public virtual DbSet<Tipodocumento> Tipodocumentos { get; set; }

    public virtual DbSet<Tipomovinventario> Tipomovinventarios { get; set; }

    public virtual DbSet<Tipopersona> Tipopersonas { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
// #warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql(Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.34-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

      



        modelBuilder.Entity<Formapago>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("formapago");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<Inventario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("inventario");

            entity.HasIndex(e => e.CodProducto, "FK_CodProducto");

            entity.HasIndex(e => e.Idpresentacion, "FK_idpresentacion");

            entity.Property(e => e.Id)
                .HasMaxLength(10)
                .HasColumnName("id");
            entity.Property(e => e.CodProducto)
                .HasMaxLength(10)
                .HasColumnName("codProducto");
            entity.Property(e => e.Idpresentacion).HasColumnName("idpresentacion");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .HasColumnName("nombre");
            entity.Property(e => e.Precio)
                .HasColumnType("double(11,2)")
                .HasColumnName("precio");
            entity.Property(e => e.Stock).HasColumnName("stock");
            entity.Property(e => e.StockMax).HasColumnName("stockMax");
            entity.Property(e => e.StockMin).HasColumnName("stockMin");

            entity.HasOne(d => d.CodProductoNavigation).WithMany(p => p.Inventarios)
                .HasForeignKey(d => d.CodProducto)
                .HasConstraintName("FK_CodProducto");

            entity.HasOne(d => d.IdpresentacionNavigation).WithMany(p => p.Inventarios)
                .HasForeignKey(d => d.Idpresentacion)
                .HasConstraintName("FK_idpresentacion");
        });

        modelBuilder.Entity<Marca>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("marca");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<Movimientoinventario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("movimientoinventario");

            entity.HasIndex(e => e.IdReceptor, "FK_idReceptor");

            entity.HasIndex(e => e.IdResponsable, "FK_idResponsable");

            entity.HasIndex(e => e.IdtipoMovInv, "fk_idTipoMovInv");

            entity.HasIndex(e => e.IdFormaPago, "idFormaPago");

            entity.Property(e => e.Id)
                .HasMaxLength(10)
                .HasColumnName("id");
            entity.Property(e => e.FechaMovimiento).HasColumnName("fechaMovimiento");
            entity.Property(e => e.FechaVencimiento).HasColumnName("fechaVencimiento");
            entity.Property(e => e.IdFormaPago).HasColumnName("idFormaPago");
            entity.Property(e => e.IdReceptor)
                .HasMaxLength(20)
                .HasColumnName("idReceptor");
            entity.Property(e => e.IdResponsable)
                .HasMaxLength(20)
                .HasColumnName("idResponsable");
            entity.Property(e => e.IdtipoMovInv).HasColumnName("idtipoMovInv");

            entity.HasOne(d => d.IdFormaPagoNavigation).WithMany(p => p.Movimientoinventarios)
                .HasForeignKey(d => d.IdFormaPago)
                .HasConstraintName("movimientoinventario_ibfk_1");

            entity.HasOne(d => d.IdReceptorNavigation).WithMany(p => p.MovimientoinventarioIdReceptorNavigations)
                .HasForeignKey(d => d.IdReceptor)
                .HasConstraintName("FK_idReceptor");

            entity.HasOne(d => d.IdResponsableNavigation).WithMany(p => p.MovimientoinventarioIdResponsableNavigations)
                .HasForeignKey(d => d.IdResponsable)
                .HasConstraintName("FK_idResponsable");

            entity.HasOne(d => d.IdtipoMovInvNavigation).WithMany(p => p.Movimientoinventarios)
                .HasForeignKey(d => d.IdtipoMovInv)
                .HasConstraintName("fk_idTipoMovInv");
        });

        modelBuilder.Entity<Pai>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("pais");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<Persona>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("persona");

            entity.HasIndex(e => e.IdDocumento, "Fk_idDocumento");

            entity.HasIndex(e => e.IdRolPersona, "Fk_idRolPersona");

            entity.HasIndex(e => e.IdTipoPersona, "Fk_idTipoPersona");

            entity.Property(e => e.Id)
                .HasMaxLength(20)
                .HasColumnName("id");
            entity.Property(e => e.FechaRegistro).HasColumnName("fechaRegistro");
            entity.Property(e => e.IdDocumento).HasColumnName("idDocumento");
            entity.Property(e => e.IdRolPersona).HasColumnName("idRolPersona");
            entity.Property(e => e.IdTipoPersona).HasColumnName("idTipoPersona");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .HasColumnName("nombre");

            entity.HasOne(d => d.IdDocumentoNavigation).WithMany(p => p.Personas)
                .HasForeignKey(d => d.IdDocumento)
                .HasConstraintName("Fk_idDocumento");

            entity.HasOne(d => d.IdRolPersonaNavigation).WithMany(p => p.Personas)
                .HasForeignKey(d => d.IdRolPersona)
                .HasConstraintName("Fk_idRolPersona");

            entity.HasOne(d => d.IdTipoPersonaNavigation).WithMany(p => p.Personas)
                .HasForeignKey(d => d.IdTipoPersona)
                .HasConstraintName("Fk_idTipoPersona");
        });

        modelBuilder.Entity<Presentacion>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("presentacion");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<Producto>(entity =>
        {
            entity.HasKey(e => e.Cod).HasName("PRIMARY");

            entity.ToTable("producto");

            entity.HasIndex(e => e.Idmarca, "Fk_idmarca");

            entity.Property(e => e.Cod)
                .HasMaxLength(10)
                .HasColumnName("cod");
            entity.Property(e => e.Idmarca).HasColumnName("idmarca");
            entity.Property(e => e.NombreProd)
                .HasMaxLength(100)
                .HasColumnName("nombreProd");

            entity.HasOne(d => d.IdmarcaNavigation).WithMany(p => p.Productos)
                .HasForeignKey(d => d.Idmarca)
                .HasConstraintName("Fk_idmarca");
        });

        modelBuilder.Entity<Rolpersona>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("rolpersona");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<Tipocontacto>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("tipocontacto");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<Tipodocumento>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("tipodocumento");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<Tipomovinventario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("tipomovinventario");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<Tipopersona>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("tipopersona");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .HasColumnName("nombre");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
