using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;

namespace Application.Repository
{
    public class ProfesorRepository : GenericRepository<Profesor>, IProfesorRepository
    {
        private readonly ApiUniversidadContext _context;

        public ProfesorRepository(ApiUniversidadContext context) : base(context)
        {
            _context = context;
        }
        public async Task<IEnumerable<object>> GetConsulta8()
        {
            var profesores = await _context.Profesores
            .OrderBy(e=>e.Persona.Apellido1)
            .ThenBy(e=>e.Persona.Apellido2)
            .ThenBy(e=>e.Persona.Nombre)
            .Select(e=> new
            {
                PrimerApellido = e.Persona.Apellido1,
                SegundoApellido = e.Persona.Apellido2,
                Nombre = e.Persona.Nombre,
                Departamento = e.Departamento.Nombre
            }).ToListAsync();

            return profesores;
        }

        public async Task<IEnumerable<object>> GetConsulta12()
        {
            var profesores = await _context.Profesores
            .OrderBy(e=>e.Departamento.Nombre)
            .ThenBy(e=>e.Persona.Apellido1)
            .ThenBy(e=>e.Persona.Nombre)
            .Select(e=>new
            {
                Departamento = e.Departamento.Nombre,
                PrimerApellido = e.Persona.Apellido1,
                SegundoApellido = e.Persona.Apellido2,
                Nombre = e.Persona.Nombre
            }).ToListAsync();

            return profesores;
        }

        public async Task<IEnumerable<object>> GetConsulta14()
        {
            var profesores = await _context.Profesores
            .Where(e=>e.Asignaturas.Any(e=>e.IdProfesorFk == null))
            .Select(e=>new
            {
                PrimerApellido = e.Persona.Apellido1,
                SegundoApellido = e.Persona.Apellido2,
                Nombre = e.Persona.Nombre
            }).ToListAsync();

            return profesores;
        }

        public async Task<IEnumerable<object>> GetConsulta25()
        {
            var profesores = await _context.Profesores
            .Select(e=> new
            {
                Id = e.Id,
                Nombre = e.Persona.Nombre,
                PrimerApellido = e.Persona.Apellido1,
                SegundoApellido = e.Persona.Apellido2,
                TotalAsignaturas = e.Asignaturas.Count
            }).OrderByDescending(t=>t.TotalAsignaturas)
            .ToListAsync();

            return profesores;
        }

        public async Task<IEnumerable<object>> GetConsulta27()
        {
            var profesores = await _context.Profesores
            .Where(e=>e.Departamento == null)
            .Select(e=>new
            {
                PrimerApellido = e.Persona.Apellido1,
                SegundoApellido = e.Persona.Apellido2,
                Nombre = e.Persona.Nombre
            }).ToListAsync();

            return profesores;
        }

        public async Task<IEnumerable<object>> GetConsulta29()
        {
            var profesor = await _context.Profesores
            .Where(e=> e.IdDepartamentoFk != null && e.Asignaturas.Count == 0)
            .Select(e=>new
            {
                PrimerApellido = e.Persona.Apellido1,
                SegundoApellido = e.Persona.Apellido2,
                Nombre = e.Persona.Nombre
            }).ToListAsync();

            return profesor;
        }

    }
}