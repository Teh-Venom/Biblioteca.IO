using Biblioteca.IO.Entity;

namespace Biblioteca.IO.Repository.Interfaces
{
    public interface ICidadeRepository
    {
        Cidade ObterPorId(int id);
    }
}