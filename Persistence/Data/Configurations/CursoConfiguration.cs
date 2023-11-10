using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Configuration;

namespace produccion.Configuration
{
    public class CursoEscolarConfiguration : IEntityTypeConfiguration<CursoEscolar>
    {
        public void Configure(EntityTypeBuilder<CursoEscolar> builder)
        {
            // Configuración de la entidad
            builder.ToTable("cursoescolar");
            
            builder.Property(e => e.Inicio)
                .IsRequired()
                .HasColumnType("YEAR(4)");

            builder.Property(e => e.Fin)
                .IsRequired()
                .HasColumnType("YEAR(4)");
        }
    }
}