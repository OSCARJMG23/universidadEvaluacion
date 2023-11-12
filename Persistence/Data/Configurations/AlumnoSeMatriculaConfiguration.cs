using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Configuration;

namespace produccion.Configuration
{
    public class AlumnoSeMatriculaAsignaturaConfiguration : IEntityTypeConfiguration<AlumnoSeMatriculaAsignatura>
    {
        public void Configure(EntityTypeBuilder<AlumnoSeMatriculaAsignatura> builder)
        {
            // Configuración de la entidad
            builder.ToTable("AlumnoSeMatriculaAsignatura");

            /* builder.HasKey(r=> new {r.IdAlumnoFk, r.IdAsignaturaFk, r.IdCursoFk});

            builder.HasOne(e => e.Alumno)
                .WithMany(e => e.AlumnoSeMatriculaAsignaturas)
                .HasForeignKey(e => e.IdAlumnoFk);

            builder.HasOne(e => e.Asignatura)
                .WithMany(e => e.AlumnoSeMatriculaAsignaturas)
                .HasForeignKey(e => e.IdAsignaturaFk);

            builder.HasOne(e => e.CursoEscolar)
                .WithMany(e => e.AlumnoSeMatriculaAsignaturas)
                .HasForeignKey(e => e.IdAsignaturaFk); */
        }
    }
}