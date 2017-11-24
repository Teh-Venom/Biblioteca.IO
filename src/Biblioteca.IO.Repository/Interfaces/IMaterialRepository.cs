using Biblioteca.IO.Entity;

namespace Biblioteca.IO.Repository.Interfaces
{
    public interface IMaterialRepository
    {
        Material ObterPorTitulo(string titulo);

        Material ObterPorEditora(Editora editora);
    }
}