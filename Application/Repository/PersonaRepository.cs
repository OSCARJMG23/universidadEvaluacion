using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;

namespace Application.Repository
{
    public class PersonaRepository : GenericRepository<Persona>, IPersonaRepository
    {
        private readonly ApiUniversidadContext _context;

        public PersonaRepository(ApiUniversidadContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Persona>> GetConsulta1()
        {
            var alumno = await _context.Personas
            .Where(e=>e.Tipo.ToLower() == "alumno")
            .OrderBy(e=>e.Apellido1)
            .ThenBy(e=>e.Apellido2)
            .ThenBy(e=>e.Nombre)
            .ToArrayAsync();

            return alumno;
        }

        public async Task<IEnumerable<Persona>> GetConsulta2()
        {
            var alumnoSinTelf = await _context.Personas
            .Where(e=>e.Tipo.ToLower() == "alumno" && e.Telefono == null)
            .ToListAsync();

            return alumnoSinTelf;
        }

        public async Task<IEnumerable<Persona>> GetConsulta3()
        {
            var alumnos1999 = await _context.Personas
            .Where(e=>e.FechaNacimiento.Year == 1999)
            .ToListAsync();

            return alumnos1999;
        }

        public async Task<IEnumerable<Persona>> GetConsulta4()
        {
            var profesoresSinTelf = await _context.Personas
            .Where(e=> e.Tipo.ToLower() == "profesor" && e.Nif.ToLower().EndsWith("k"))
            .ToListAsync();

            return profesoresSinTelf;
        }

        public async Task<IEnumerable<Persona>> GetConsulta6()
        {
            var alumnas = await _context.Personas
            .Where(e=> e.Tipo.ToLower() == "alumno" && e.Sexo.ToLower() == "mujer" && 
                    e.AlumnoSeMatriculaAsignaturas.Any(e=>e.Asignatura.Grado.Nombre == "Grado en Ingeniería Informática (Plan 2015)"))
            .ToListAsync();

            return alumnas;
        }

        public async Task<IEnumerable<Persona>> GetConsulta11()
        {
            var alumnos = await _context.Personas
            .Where(e=> e.Tipo.ToLower() == "alumno" && e.AlumnoSeMatriculaAsignaturas.Any(e=>e.CursoEscolar.Inicio == 2018 && e.CursoEscolar.Fin == 2019))
            .ToListAsync();

            return alumnos;
        }

        public async Task<int>GetConsulta17()
        {
            var totalAlumans = await _context.Personas
            .Where(e=> e.Tipo.ToLower() == "alumno" && e.Sexo.ToLower() =="mujer")
            .CountAsync();

            return totalAlumans;
        }

        public async Task<int>GetConsulta18()
        {
            var total = await _context.Personas
            .Where(e=>e.Tipo.ToLower() == "alumno" && e.FechaNacimiento.Year ==1999)
            .CountAsync();

            return total;
        }

        public async Task<Persona>GetConsulta26()
        {
            var alumno = await _context.Personas
            .Where(e=> e.Tipo.ToLower() == "alumno")
            .OrderByDescending(e => e.FechaNacimiento)
            .FirstOrDefaultAsync();

            return alumno;
        }

        
    }
}