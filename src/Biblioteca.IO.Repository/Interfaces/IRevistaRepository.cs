using System.Collections.Generic;
using Biblioteca.IO.Entity;

namespace Biblioteca.IO.Repository.Interfaces
{
    public interface IRevistaRepository
    {
        List<Revista> ObterPorColecao(string colecao);

    }
}