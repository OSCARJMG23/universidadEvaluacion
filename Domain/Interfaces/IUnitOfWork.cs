
namespace Domain.Interfaces
{
    public interface IUnitOfWork
    {
        IAsignaturaRepository Asignaturas {get;}
        ICursoEscolarRepository Cursos {get;}
        IDepartamentoRepository Departamentos {get;}
        IGradoRepository Grados {get;}
        IPersonaRepository Personas {get;}
        IProfesorRepository Profesores {get;}
        Task<int> SaveAsync();
    }
}