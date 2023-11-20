using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration
{
    public class DetallemovinventarioConfiguration : IEntityTypeConfiguration<Detallemovinventario>
    {

        public void Configure(EntityTypeBuilder<Detallemovinventario> builder)
        {
            builder.HasKey(e => new { e.IdInventario, e.IdMovInv })
                .HasName("builderRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

            builder.ToTable("detallemovinventario");

            builder.HasIndex(e => e.IdMovInv, "FK_idMovInv");

            builder.Property(e => e.IdInventario)
                 .HasMaxLength(10)
                 .HasColumnName("idInventario");
            builder.Property(e => e.IdMovInv)
                .HasMaxLength(10)
                .HasColumnName("idMovInv");
                
            builder.Property(e => e.Cantidad).HasColumnName("cantidad");
            builder.Property(e => e.Precio)
                  .HasColumnType("double(11,2)")
                  .HasColumnName("precio");

            builder.HasOne(d => d.IdInventarioNavigation).WithMany(p => p.Detallemovinventarios)
                .HasForeignKey(d => d.IdInventario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_idInventario");

            builder.HasOne(d => d.IdMovInvNavigation).WithMany(p => p.Detallemovinventarios)
                .HasForeignKey(d => d.IdMovInv)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_idMovInv");
        }
    }
}