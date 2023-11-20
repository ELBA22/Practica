using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration
{
    public class FacturaConfiguration : IEntityTypeConfiguration<Factura>
    {
        public void Configure(EntityTypeBuilder<Factura> builder)
        {
            builder.HasKey(e => e.Id).HasName("PRIMARY");

            builder.ToTable("factura");

            builder.Property(e => e.Id).HasColumnName("id");
            builder.Property(e => e.FacturaActual).HasColumnName("facturaActual");
            builder.Property(e => e.FacturaFinal).HasColumnName("facturaFinal");
            builder.Property(e => e.FacturaInicial).HasColumnName("facturaInicial");
            builder.Property(e => e.NroResolucion)
                .HasMaxLength(10)
                .HasColumnName("nroResolucion");
        }
    }
}