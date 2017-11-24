using Biblioteca.IO.Entity;

namespace Biblioteca.IO.Repository.Interfaces
{
    public interface IEnderecoRepository
    {
        Endereco ObterPorId(int id);
    }
}