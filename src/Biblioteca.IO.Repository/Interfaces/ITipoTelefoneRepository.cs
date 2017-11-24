using Biblioteca.IO.Entity;

namespace Biblioteca.IO.Repository.Interfaces
{
    public interface ITipoTelefoneRepository
    {
        TipoTelefone ObterPorId(int id);
    }
}