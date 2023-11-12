using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;

namespace Application.Repository
{
    public class GradoRepository : GenericRepository<Grado>, IGradoRepository
    {
        private readonly ApiUniversidadContext _context;

        public GradoRepository(ApiUniversidadContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<object>> GetConsulta21()
        {
            var grados = await _context.Grados
            .Select(e=> new
            {
                NombreGrado = e.Nombre,
                TotalAsignaturas = e.Asignaturas.Count
            }).OrderByDescending(t=>t.TotalAsignaturas)
            .ToListAsync();

            return grados;
        }
        public async Task<IEnumerable<object>> GetConsulta22()
        {
            var grados = await _context.Grados
            .Where(e=> e.Asignaturas.Count >=40)
            .Select(e=> new
            {
                NombreGrado = e.Nombre,
                TotalAsignaturas = e.Asignaturas.Count
            }).OrderByDescending(t=>t.TotalAsignaturas)
            .ToListAsync();

            return grados;
        }
        public async Task<IEnumerable<object>> GetConsulta23()
        {
            var grados = await _context.Grados
            .SelectMany(e=>e.Asignaturas)
            .GroupBy(e =>new{e.IdGradoFk, e.Tipo})
            .Select(e=> new
            {
                NombreGrado = e.FirstOrDefault().Grado.Nombre,
                TipoAsignatura = e.Key.Tipo,
                TotalCreditos = e.Sum(f=>f.Creditos)
            }).OrderByDescending(t=>t.TotalCreditos)
            .ToListAsync();

            return grados;
        }
    }
}