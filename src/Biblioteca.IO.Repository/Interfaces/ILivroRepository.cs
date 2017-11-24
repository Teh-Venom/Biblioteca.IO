using System.Collections.Generic;
using Biblioteca.IO.Entity;

namespace Biblioteca.IO.Repository.Interfaces
{
    public interface ILivroRepository
    {
        Livro ObterPorIsbn(string isbn);

        List<Livro> ObterPorAutor(Autor autor);

        void CadastrarLivro(Livro livro);

        void AlterarLivro(Livro livro);
    }
}