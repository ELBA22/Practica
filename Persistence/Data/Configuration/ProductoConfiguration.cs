using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration
{
    public class ProductoConfiguration : IEntityTypeConfiguration<Producto>
    {
        public void Configure(EntityTypeBuilder<Producto> builder)
        {
            builder.HasKey(e => e.Cod).HasName("PRIMARY");

            builder.ToTable("producto");

            builder.HasIndex(e => e.Idmarca, "Fk_idmarca");

            builder.Property(e => e.Cod)
                .HasMaxLength(10)
                .HasColumnName("cod");
                
            builder.Property(e => e.Idmarca).HasColumnName("idmarca");
            builder.Property(e => e.NombreProd)
                .HasMaxLength(100)
                .HasColumnName("nombreProd");

            builder.HasOne(d => d.IdmarcaNavigation).WithMany(p => p.Productos)
                .HasForeignKey(d => d.Idmarca)
                .HasConstraintName("Fk_idmarca");
        }
    }
}