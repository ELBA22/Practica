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
    public class TipopersonaConfiguration : IEntityTypeConfiguration<Tipopersona>
    {
        public void Configure(EntityTypeBuilder<Tipopersona> builder)
        {
            builder.HasKey(e => e.Id).HasName("PRIMARY");

            builder.ToTable("tipopersona");

            builder.Property(e => e.Id).HasColumnName("id");
            builder.Property(e => e.Nombre)
                  .HasMaxLength(50)
                  .HasColumnName("nombre");
        }
    }
}