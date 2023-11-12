using Domain.Entities;
using Dominio.Interfaces;

namespace Domain.Interfaces
{
    public interface IProfesorRepository : IGenericRepository<Profesor>
    {
        Task<IEnumerable<object>> GetConsulta8(); 
        Task<IEnumerable<object>> GetConsulta12();
        Task<IEnumerable<object>> GetConsulta14();
        Task<IEnumerable<object>> GetConsulta25();
        Task<IEnumerable<object>> GetConsulta27();

        Task<IEnumerable<object>> GetConsulta29();
    }
}