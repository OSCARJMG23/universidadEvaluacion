using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Asignatura : BaseEntity
    {
        public string Nombre { get; set; }
        public float Creditos { get; set; }
        public enum Tipo { Basica, Obligatoria }
        public int Curso { get; set; }
        public int Cuatrimestre { get; set; }
        public int IdProfesorFk { get; set; }
        public Profesor Profesor { get; set; }
        public int IdGradoFk { get; set; }
        public Grado Grado { get; set; }
        public ICollection<AlumnoSeMatriculaAsignatura> AlumnoSeMatriculaAsignaturas { get; set; }
        public ICollection<Persona> Personas { get; set; }
    }
}