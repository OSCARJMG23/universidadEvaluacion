using Domain.Entities;
using Dominio.Interfaces;

namespace Domain.Interfaces
{
    public interface IDepartamentoRepository : IGenericRepository<Departamento>
    {
        Task<IEnumerable<Departamento>> GetConsulta10();
        Task<IEnumerable<Departamento>> GetConsulta13();
        Task<IEnumerable<object>> GetConsulta16();
        Task<IEnumerable<object>> GetConsulta19();
        Task<IEnumerable<object>> GetConsulta20();
        Task<IEnumerable<Departamento>> GetConsulta28();
        Task<IEnumerable<Departamento>> GetConsulta31();
    }
}