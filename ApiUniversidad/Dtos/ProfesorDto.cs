using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiUniversidad.Dtos
{
    public class ProfesorDto
    {
        public int Id { get; set; }
        public int IdDepartamentoFk { get; set; }
    }
}