using Biblioteca.IO.Entity;

namespace Biblioteca.IO.Repository.Interfaces
{
    public interface IEstadoRepository
    {
        Estado ObterPorId(int id);
    }
}