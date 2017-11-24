using Biblioteca.IO.Entity;

namespace Biblioteca.IO.Repository.Interfaces
{
    public interface IAutorRepository
    {
        Autor ObterPorId(int id);

        void CadastrarAutor(Autor autor);
    }
}