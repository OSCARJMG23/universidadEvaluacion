using Domain.Entities;
using Dominio.Interfaces;

namespace Domain.Interfaces
{
    public interface ICursoEscolarRepository : IGenericRepository<CursoEscolar>
    {
        Task<IEnumerable<object>> GetConsulta24(); 
    }
}