using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiUniversidad.Dtos
{
    public class AsignaturaPerDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public float Creditos { get; set; }
        public string Tipo { get; set; }
        public int Curso { get; set; }
        public int Cuatrimestre { get; set; }
        public GradoDto Grado { get; set; }
    }
}