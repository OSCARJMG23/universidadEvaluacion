using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;

namespace Application.Repository
{
    public class CursoEscolarRepository : GenericRepository<CursoEscolar>, ICursoEscolarRepository
    {
        private readonly ApiUniversidadContext _context;

        public CursoEscolarRepository(ApiUniversidadContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<object>> GetConsulta24()
        {
            var cursos = await _context.CursosEscolares
            .Select(e=>new
            {
                AñoInicio = e.Inicio,
                TotalAlumnosMatriculados = e.AlumnoSeMatriculaAsignaturas.Count
            }).ToListAsync();

            return cursos;
        }
    }
}