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

            builder.Property(e => e.Tipo)
                .IsRequired()
                .HasColumnType("varchar")
                .HasMaxLength(12);

            builder.Property(e => e.Curso)
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

            builder.HasMany(e => e.Personas)
                .WithMany(r => r.Asignaturas)
                .UsingEntity<AlumnoSeMatriculaAsignatura>(
                    j =>
                    {
                        j.HasOne(p => p.Asignatura)
                         .WithMany(p => p.AlumnoSeMatriculaAsignaturas)
                         .HasForeignKey(p => p.IdAsignaturaFk);
            
                        j.HasOne(e => e.Alumno)
                         .WithMany(e => e.AlumnoSeMatriculaAsignaturas)
                         .HasForeignKey(e => e.IdAlumnoFk);

                        j.HasOne(e=>e.CursoEscolar)
                        .WithMany(e=>e.AlumnoSeMatriculaAsignaturas)
                        .HasForeignKey(e=>e.IdCursoFk);
            
                        j.ToTable("AlumnoSeMatriculaAsignatura");
                        j.HasKey(t => new { t.IdAsignaturaFk, t.IdAlumnoFk, t.IdCursoFk });
                    });
        }
    }
}