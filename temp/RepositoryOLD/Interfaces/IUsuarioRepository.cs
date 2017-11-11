using System.Collections;
using System.Collections.Generic;
using Biblioteca.IO.Entity;

namespace Biblioteca.IO.Repository.Interfaces
{
    public interface IUsuarioRepository
    {
        void Inserir(Usuario usuario);
        
        Usuario Obter(int id);
        
        ICollection<Usuario> ObterPorNome(string nome);
        
        void Deletar(int id);

        void Atualizar(Usuario usuario);

    }
}