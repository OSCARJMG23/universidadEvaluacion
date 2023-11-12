using Domain.Entities;
using Dominio.Interfaces;

namespace Domain.Interfaces
{
    public interface IGradoRepository : IGenericRepository<Grado>
    {
        Task<IEnumerable<object>> GetConsulta21(); 
        Task<IEnumerable<object>> GetConsulta22();
        Task<IEnumerable<object>> GetConsulta23();
    }
}