using System.Collections.Generic;
using Biblioteca.IO.Entity;

namespace Biblioteca.IO.Repository.Interfaces
{
    public interface ITelefoneRepository
    {
        Telefone ObterPorid(int id);

        List<Telefone> ObterPorIdPessoa(Pessoa pessoa);

    }
}