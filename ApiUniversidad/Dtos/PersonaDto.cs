using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiUniversidad.Dtos
{
    public class PersonaDto
    {
        public int Id { get; set; }
        public string Nif { get; set; }
        public string Nombre { get; set; }
        public string Apellido1 { get; set; }
        public string Apellido2 { get; set; }
        public string Ciudad { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public DateTime  FechaNacimiento { get; set; }
        public string Sexo { get; set; }
        public string Tipo { get; set; }
    }
}