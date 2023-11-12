using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Configuration;

namespace produccion.Configuration
{
    public class PersonaConfiguration : IEntityTypeConfiguration<Persona>
    {
        public void Configure(EntityTypeBuilder<Persona> builder)
        {
            // Configuración de la entidad
            builder.ToTable("persona");
            
            builder.Property(e => e.Nif)
                .IsRequired()
                .HasMaxLength(9);

            builder.Property(e => e.Nombre)
                .IsRequired()
                .HasMaxLength(25);

            builder.Property(e => e.Apellido1)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(e => e.Apellido2)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(e => e.Ciudad)
                .IsRequired()
                .HasMaxLength(25);

            builder.Property(e => e.Direccion)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(e => e.Telefono)
                .HasMaxLength(9);

            builder.Property(e => e.Sexo)
                .IsRequired()
                .HasMaxLength(10);

            builder.Property(e => e.Tipo)
                .IsRequired()
                .HasMaxLength(10);
            
        }
    }
}