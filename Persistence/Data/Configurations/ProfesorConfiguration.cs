using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Configuration;

namespace produccion.Configuration
{
    public class ProfesorConfiguration : IEntityTypeConfiguration<Profesor>
    {
        public void Configure(EntityTypeBuilder<Profesor> builder)
        {
            // Configuración de la entidad
            builder.ToTable("profesor");

            builder.HasKey(t=> t.IdProfesor);

            builder.HasOne(e => e.Persona)
                .WithMany(e => e.Profesores)
                .HasForeignKey(e => e.IdProfesor);

            builder.HasOne(e => e.Departamento)
                .WithMany(e => e.Profesores)
                .HasForeignKey(e => e.IdDepartamentoFk);
        }
    }
}