using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Configuration;

namespace produccion.Configuration
{
    public class AsignaturaConfiguration : IEntityTypeConfiguration<Asignatura>
    {
        public void Configure(EntityTypeBuilder<Asignatura> builder)
        {
            // Configuración de la entidad
            builder.ToTable("asignatura");
            
            builder.Property(e => e.Nombre)
                .IsRequired()
                .HasMaxLength(100);
            
            builder.Property(e => e.Creditos)
                .IsRequired()
                .HasColumnType("float");

            builder.Property(e => e.Curso)
                .IsRequired()
                .HasColumnType("int");

            builder.Property(e => e.Cuatrimestre)
                .IsRequired()
                .HasColumnType("int");
            
            builder.HasOne(e => e.Profesor)
                .WithMany(e => e.Asignaturas)
                .HasForeignKey(e => e.IdProfesorFk);

            builder.HasOne(e => e.Grado)
                .WithMany(e => e.Asignaturas)
                .HasForeignKey(e => e.IdGradoFk);
        }
    }
}