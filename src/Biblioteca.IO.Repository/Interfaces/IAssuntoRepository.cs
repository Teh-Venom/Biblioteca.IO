using Biblioteca.IO.Entity;

namespace Biblioteca.IO.Repository.Interfaces
{
    public interface IAssuntoRepository
    {
        Assunto ObterPorId(int id);
    }
}