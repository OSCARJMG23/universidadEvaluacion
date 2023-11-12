using Domain.Entities;
using Dominio.Interfaces;

namespace Domain.Interfaces
{
    public interface IPersonaRepository : IGenericRepository<Persona>
    {
        Task<IEnumerable<Persona>> GetConsulta1();
        Task<IEnumerable<Persona>> GetConsulta2();
        Task<IEnumerable<Persona>> GetConsulta3();
        Task<IEnumerable<Persona>> GetConsulta4();
        Task<IEnumerable<Persona>> GetConsulta6();
        Task<IEnumerable<Persona>> GetConsulta11();
        Task<int>GetConsulta17();
        Task<int>GetConsulta18();
        Task<Persona>GetConsulta26();
    }
}