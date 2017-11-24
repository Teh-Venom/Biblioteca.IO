using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Biblioteca.IO.Entity;
using Biblioteca.IO.Repository.Interfaces;
using FluentValidation;
using FluentValidation.Results;

namespace Biblioteca.IO.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        public List<Usuario> ObterPorEmail(string email)
        {
            throw new NotImplementedException();
        }

        public bool VerificarUsuarioExistente(string email)
        {
            throw new NotImplementedException();
        }

        public bool VerificarUsuarioDesativado(int id)
        {
            throw new NotImplementedException();
        }

        public Usuario ObterPorId(int id)
        {
            throw new NotImplementedException();
        }

        public void AlterarSenha(Usuario obj)
        {
            throw new NotImplementedException();
        }

        public void DesativarUsuario(int id)
        {
            throw new NotImplementedException();
        }

        public void CadastrarUsuario(Usuario obj)
        {
            throw new NotImplementedException();
        }
    }
}