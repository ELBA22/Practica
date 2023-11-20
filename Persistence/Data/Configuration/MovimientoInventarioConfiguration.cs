using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration
{
    public class MovimientoInventarioConfiguration : IEntityTypeConfiguration<Movimientoinventario>
    {
        public void Configure(EntityTypeBuilder<Movimientoinventario> builder)
        {
            builder.HasKey(e => e.Id).HasName("PRIMARY");

            builder.ToTable("movimientoinventario");

            builder.HasIndex(e => e.IdReceptor, "FK_idReceptor");

            builder.HasIndex(e => e.IdResponsable, "FK_idResponsable");

            builder.HasIndex(e => e.IdtipoMovInv, "fk_idTipoMovInv");

            builder.HasIndex(e => e.IdFormaPago, "idFormaPago");

            builder.Property(e => e.Id)
                    .HasMaxLength(10)
                    .HasColumnName("id");
                    
            builder.Property(e => e.FechaMovimiento).HasColumnName("fechaMovimiento");
            builder.Property(e => e.FechaVencimiento).HasColumnName("fechaVencimiento");
            builder.Property(e => e.IdFormaPago).HasColumnName("idFormaPago");
            builder.Property(e => e.IdReceptor)
                    .HasMaxLength(20)
                    .HasColumnName("idReceptor");

            builder.Property(e => e.IdResponsable)
                    .HasMaxLength(20)
                    .HasColumnName("idResponsable");
            builder.Property(e => e.IdtipoMovInv).HasColumnName("idtipoMovInv");

            builder.HasOne(d => d.IdFormaPagoNavigation).WithMany(p => p.Movimientoinventarios)
                .HasForeignKey(d => d.IdFormaPago)
                .HasConstraintName("movimientoinventario_ibfk_1");

            builder.HasOne(d => d.IdReceptorNavigation).WithMany(p => p.MovimientoinventarioIdReceptorNavigations)
                    .HasForeignKey(d => d.IdReceptor)
                    .HasConstraintName("FK_idReceptor");

            builder.HasOne(d => d.IdResponsableNavigation).WithMany(p => p.MovimientoinventarioIdResponsableNavigations)
                    .HasForeignKey(d => d.IdResponsable)
                    .HasConstraintName("FK_idResponsable");

            builder.HasOne(d => d.IdtipoMovInvNavigation).WithMany(p => p.Movimientoinventarios)
                    .HasForeignKey(d => d.IdtipoMovInv)
                    .HasConstraintName("fk_idTipoMovInv");
        }
    }
}