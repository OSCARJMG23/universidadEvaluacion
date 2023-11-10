using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Persona : BaseEntity
    {
        public string Nif { get; set; }
        public string Nombre { get; set; }
        public string Apellido1 { get; set; }
        public string Apellido2 { get; set; }
        public string Ciudad { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public DateTime  FechaNacimiento { get; set; }
        public enum Sexo { H, M }
        public enum Tipo { Alumno, Profesor }
        public ICollection<AlumnoSeMatriculaAsignatura> AlumnoSeMatriculaAsignaturas { get; set; }
        public ICollection<Asignatura> Asignaturas { get; set; }
        public ICollection<Profesor> Profesores { get; set; }
    }
}