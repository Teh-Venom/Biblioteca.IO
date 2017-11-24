using System.Collections.Generic;
using Biblioteca.IO.Entity;

namespace Biblioteca.IO.Repository.Interfaces
{
    public interface IArtigoRepository
    {
        List<Artigo> ObterPorRevista(Revista revista);

        List<Artigo> ObterPorAutor(Autor autor);
    }
}