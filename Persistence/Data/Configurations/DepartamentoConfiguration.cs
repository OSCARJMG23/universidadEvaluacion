using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Configuration;

namespace produccion.Configuration
{
    public class DepartamentoConfiguration : IEntityTypeConfiguration<Departamento>
    {
        public void Configure(EntityTypeBuilder<Departamento> builder)
        {
            // Configuración de la entidad
            builder.ToTable("departamento");

            builder.Property(e => e.Nombre)
                .IsRequired()
                .HasMaxLength(50);
        }
    }
}