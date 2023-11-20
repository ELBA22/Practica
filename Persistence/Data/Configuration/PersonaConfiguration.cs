using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration
{
    public class PersonaConfiguration : IEntityTypeConfiguration<Persona>
    {
        public void Configure(EntityTypeBuilder<Persona> builder)
        {
            builder.HasKey(e => e.Id).HasName("PRIMARY");

            builder.ToTable("persona");

            builder.HasIndex(e => e.IdDocumento, "Fk_idDocumento");

            builder.HasIndex(e => e.IdRolPersona, "Fk_idRolPersona");

            builder.HasIndex(e => e.IdTipoPersona, "Fk_idTipoPersona");

            builder.Property(e => e.Id)
                    .HasMaxLength(20)
                    .HasColumnName("id");
            builder.Property(e => e.FechaRegistro).HasColumnName("fechaRegistro");
            builder.Property(e => e.IdDocumento).HasColumnName("idDocumento");
            builder.Property(e => e.IdRolPersona).HasColumnName("idRolPersona");
            builder.Property(e => e.IdTipoPersona).HasColumnName("idTipoPersona");
            builder.Property(e => e.Nombre)
                .HasMaxLength(50)
                .HasColumnName("nombre");

            builder.HasOne(d => d.IdDocumentoNavigation).WithMany(p => p.Personas)
                    .HasForeignKey(d => d.IdDocumento)
                    .HasConstraintName("Fk_idDocumento");

            builder.HasOne(d => d.IdRolPersonaNavigation).WithMany(p => p.Personas)
                    .HasForeignKey(d => d.IdRolPersona)
                    .HasConstraintName("Fk_idRolPersona");

            builder.HasOne(d => d.IdTipoPersonaNavigation).WithMany(p => p.Personas)
                    .HasForeignKey(d => d.IdTipoPersona)
                    .HasConstraintName("Fk_idTipoPersona");
        }
    }
}