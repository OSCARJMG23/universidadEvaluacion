using Application.Repository;
using Domain.Interfaces;
using Persistence.Data;

namespace Application.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly ApiUniversidadContext _context;
        private IAsignaturaRepository _asignaturas;
        private ICursoEscolarRepository _cursos;
        private IDepartamentoRepository _departamentos;
        private IGradoRepository _grados;
        private IPersonaRepository _personas;
        private IProfesorRepository _profesores;

        public UnitOfWork(ApiUniversidadContext context)
        {
            _context = context;
        }
        public IAsignaturaRepository Asignaturas
        {
            get
            {
                if (_asignaturas == null)
                {
                    _asignaturas = new AsignaturaRepository(_context);
                }
                return _asignaturas;
            }
        }

        public ICursoEscolarRepository Cursos
        {
            get
            {
                if (_cursos == null)
                {
                    _cursos = new CursoEscolarRepository(_context);
                }
                return _cursos;
            }
        }

        public IDepartamentoRepository Departamentos
        {
            get
            {
                if (_departamentos == null)
                {
                    _departamentos = new DepartamentoRepository(_context);
                }
                return _departamentos;
            }
        }

        public IGradoRepository Grados
        {
            get
            {
                if (_grados == null)
                {
                    _grados = new GradoRepository(_context);
                }
                return _grados;
            }
        }

        public IPersonaRepository Personas
        {
            get
            {
                if (_personas == null)
                {
                    _personas = new PersonaRepository(_context);
                }
                return _personas;
            }
        }

        public IProfesorRepository Profesores
        {
            get
            {
                if (_profesores == null)
                {
                    _profesores = new ProfesorRepository(_context);
                }
                return _profesores;
            }
        }

        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}