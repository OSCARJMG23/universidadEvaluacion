using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;

namespace Application.Repository
{
    public class AsignaturaRepository : GenericRepository<Asignatura>, IAsignaturaRepository
    {
        private readonly ApiUniversidadContext _context;
        public AsignaturaRepository(ApiUniversidadContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Asignatura>> GetConsulta5()
        {
            var asignatura = await _context.Asignaturas
            .Where(e=> e.Cuatrimestre ==1 && e.Curso == 3 && e.Grado.Id == 7)
            .Include(e=> e.Grado)
            .ToListAsync();

            return asignatura;
        }

        public async Task<IEnumerable<Asignatura>> GetConsulta7()
        {
            var asignatura = await _context.Asignaturas
            .Where(e=> e.Grado.Nombre == "Grado en Ingeniería Informática (Plan 2015)")
            .Include(e=>e.Grado)
            .ToListAsync();

            return asignatura;
        }

        public async Task<IEnumerable<object>> GetConsulta9()
        {
            var asignatura = await _context.Asignaturas
            .Where(e=> e.AlumnoSeMatriculaAsignaturas.Any(e=>e.Alumno.Nif =="26902806M"))
            .Select(e=> new
            {
                NombreAsignatura = e.Nombre,
                AñoDeInicio = e.AlumnoSeMatriculaAsignaturas.Where(e=> e.Alumno.Nif =="26902806M").Select(e=>e.CursoEscolar.Inicio).FirstOrDefault(),
                AñoFinal = e.AlumnoSeMatriculaAsignaturas.Where(e=> e.Alumno.Nif =="26902806M").Select(e=>e.CursoEscolar.Fin).FirstOrDefault()
            }).ToListAsync();

            return asignatura;
        }

        public async Task<IEnumerable<Asignatura>> GetConsulta15()
        {
            var asignatura = await _context.Asignaturas
            .Where(e=>e.IdProfesorFk == null)
            .ToListAsync();

            return asignatura;
        }
        public async Task<IEnumerable<Asignatura>> GetConsulta30()
        {
            var asignatura = await _context.Asignaturas
            .Where(e=>e.IdProfesorFk == null)
            .ToListAsync();

            return asignatura;
        }

    }
}