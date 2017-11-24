using System.Collections.Generic;
using Biblioteca.IO.Entity;

namespace Biblioteca.IO.Repository.Interfaces
{
    public interface IUsuarioRepository
        {

         List<Usuario> ObterPorEmail(string email);

         bool VerificarUsuarioExistente(Usuario usuario);

         bool VerificarUsuarioDesativado(Usuario usuario);

         Usuario ObterPorId(int id);

         void AlterarSenha(Usuario usuario);

         void DesativarUsuario(Usuario usuario);

         void CadastrarUsuario(Usuario usuario);
    }
}