using Biblioteca.IO.Entity;
using Biblioteca.IO.Repository.Interfaces;
using FluentValidation;
using FluentValidation.Results;

namespace Biblioteca.IO.Repository
{
    public class UsuarioRepository : ICrudInterface<Usuario>
    {
        public void Inserir(Usuario obj)
        {
            throw new System.NotImplementedException();
        }

        public Usuario Obter(int id)
        {
            throw new System.NotImplementedException();
        }

        public void Deletar(int id)
        {
            throw new System.NotImplementedException();
        }

        public void Atualizar(Usuario obj)
        {
            throw new System.NotImplementedException();
        }
    }
}