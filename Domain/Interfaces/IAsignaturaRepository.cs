using Domain.Entities;
using Dominio.Interfaces;

namespace Domain.Interfaces
{
    public interface IAsignaturaRepository : IGenericRepository<Asignatura>
    {
        Task<IEnumerable<Asignatura>> GetConsulta5(); 
        Task<IEnumerable<Asignatura>> GetConsulta7();
        Task<IEnumerable<object>> GetConsulta9();
        Task<IEnumerable<Asignatura>> GetConsulta15();
        Task<IEnumerable<Asignatura>> GetConsulta30();
    }
}