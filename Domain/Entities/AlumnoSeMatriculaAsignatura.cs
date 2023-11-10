using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class AlumnoSeMatriculaAsignatura
    {
        public int IdAlumnoFk { get; set; }
        public Persona Alumno { get; set; }
        public int IdAsignaturaFk { get; set; }
        public Asignatura Asignatura { get; set; }
        public int IdCursoFk { get; set; }
        public CursoEscolar CursoEscolar { get; set; }
    }
}