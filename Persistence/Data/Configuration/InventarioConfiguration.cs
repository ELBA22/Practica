using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration
{
    public class InventarioConfiguration : IEntityTypeConfiguration<Inventario>
    {
        public void Configure(EntityTypeBuilder<Inventario> builder)
        {
            builder.HasKey(e => e.Id).HasName("PRIMARY");

            builder.ToTable("inventario");

            builder.HasIndex(e => e.CodProducto, "FK_CodProducto");

            builder.HasIndex(e => e.Idpresentacion, "FK_idpresentacion");

            builder.Property(e => e.Id)
                .HasMaxLength(10)
                .HasColumnName("id");
            builder.Property(e => e.CodProducto)
                .HasMaxLength(10)
                .HasColumnName("codProducto");

            builder.Property(e => e.Idpresentacion).HasColumnName("idpresentacion");
            builder.Property(e => e.Nombre)
                .HasMaxLength(50)
                .HasColumnName("nombre");
                
            builder.Property(e => e.Precio)
                .HasColumnType("double(11,2)")
                .HasColumnName("precio");
            builder.Property(e => e.Stock).HasColumnName("stock");
            builder.Property(e => e.StockMax).HasColumnName("stockMax");
            builder.Property(e => e.StockMin).HasColumnName("stockMin");

            builder.HasOne(d => d.CodProductoNavigation).WithMany(p => p.Inventarios)
                .HasForeignKey(d => d.CodProducto)
                .HasConstraintName("FK_CodProducto");

            builder.HasOne(d => d.IdpresentacionNavigation).WithMany(p => p.Inventarios)
                .HasForeignKey(d => d.Idpresentacion)
                .HasConstraintName("FK_idpresentacion");
        }
    }
}