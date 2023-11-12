using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;

namespace Application.Repository
{
    public class DepartamentoRepository : GenericRepository<Departamento>, IDepartamentoRepository
    {
        private readonly ApiUniversidadContext _context;

        public DepartamentoRepository(ApiUniversidadContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Departamento>> GetConsulta10()
        {
            var Departamento = await _context.Departamentos
            .Where(e=>e.Profesores.Any(e=>e.Asignaturas.Any(e=>e.Grado.Nombre == "Grado en Ingeniería Informática (Plan 2015)")))
            .ToListAsync();

            return Departamento;
        }
        
        public async Task<IEnumerable<Departamento>> GetConsulta13()
        {
            var Departamento = await _context.Departamentos
            .Where(e=>e.Profesores.Any(e=>e.Departamento == null))
            .ToListAsync();

            return Departamento;
        }

        public async Task<IEnumerable<object>> GetConsulta16()
        {
            var asignaturasNoImpartidas = await _context.Asignaturas
            .Where(a => !a.AlumnoSeMatriculaAsignaturas.Any())
            .Select(e=>new
            {
                NombreDepartamento = e.Profesor.Departamento.Nombre,
                NombreAsignatura = e.Nombre
            })
            .ToListAsync();

            

            return asignaturasNoImpartidas;
        }

        public async Task<IEnumerable<object>> GetConsulta19()
        {
            var departamentos = await _context.Departamentos
            .Where(e=>e.Profesores.Count >=1)
            .Select(e=> new
            {
                NombreDepartamento = e.Nombre,
                TotalProfesores = e.Profesores.Count
            }).OrderByDescending(t=>t.TotalProfesores)
            .ToArrayAsync();

            return departamentos;
        }

        public async Task<IEnumerable<object>> GetConsulta20()
        {
            var departamentos = await _context.Departamentos
            .Select(e=> new
            {
                NombreDepartamento = e.Nombre,
                TotalProfesores = e.Profesores.Count
            }).OrderByDescending(t=>t.TotalProfesores)
            .ToArrayAsync();

            return departamentos;
        }

        public async Task<IEnumerable<Departamento>> GetConsulta28()
        {
            var Departamento = await _context.Departamentos
            .Where(e=>e.Profesores == null)
            .ToListAsync();

            return Departamento;
        }
        
        public async Task<IEnumerable<Departamento>> GetConsulta31()
        {
            var Departamento = await _context.Departamentos
            .Where(e=>e.Profesores.Any(e=>e.Asignaturas.Any(t=>t.AlumnoSeMatriculaAsignaturas == null)))
            .ToListAsync();

            return Departamento;
        }
    }
}