using System.Collections.Generic;
using Biblioteca.IO.Entity;

namespace Biblioteca.IO.Repository.Interfaces
{
    public interface IUsuarioRepository
        {
         void Inserir(Usuario obj);

        Usuario Obter(int id);

         List<Usuario> ObterPorEmail(string email);

         bool VerificarUsuarioExistente(string email);

         bool VerificarUsuarioDesativado(int id);

         void Deletar(int id);

         void Atualizar(Usuario obj);

         void AtribuirPessoa(int idPessoa);

         void DesativarUsuario(int id);
    }
}