using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration
{
    public class ContactoPersonaConfiguration : IEntityTypeConfiguration<Contactopersona>
    {
        public void Configure(EntityTypeBuilder<Contactopersona> builder)
        {
            builder.HasKey(e => e.Id).HasName("PRIMARY");

            builder.ToTable("contactopersona");

            builder.HasIndex(e => e.IdPersona, "FK_idPersonaContacto");

            builder.HasIndex(e => e.IdTipoContacto, "FK_idTipoContacto");

            builder.Property(e => e.Id).HasColumnName("id");
            builder.Property(e => e.IdPersona)
                .HasMaxLength(20)
                .HasColumnName("idPersona");
            builder.Property(e => e.IdTipoContacto).HasColumnName("idTipoContacto");

            builder.HasOne(d => d.IdPersonaNavigation).WithMany(p => p.Contactopersonas)
                .HasForeignKey(d => d.IdPersona)
                .HasConstraintName("FK_idPersonaContacto");

            builder.HasOne(d => d.IdTipoContactoNavigation).WithMany(p => p.Contactopersonas)
                .HasForeignKey(d => d.IdTipoContacto)
                .HasConstraintName("FK_idTipoContacto");
        }
    }
}