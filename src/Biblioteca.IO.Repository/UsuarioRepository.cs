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


        public void Inserir(Usuario obj) //cadastrar usuario
        {
            throw new NotImplementedException();
        }

        public Usuario Obter(int id) //obter por id
        {
            throw new NotImplementedException();
        }

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

        public void Deletar(int id) //será excluido logicamente
        {
            throw new NotImplementedException();
        }

        public void Atualizar(Usuario obj) 
        {
            throw new NotImplementedException();
        }

        public void AtribuirPessoa(int idPessoa)
        {
            throw new NotImplementedException();
        }

        public void DesativarUsuario(int id)
        {
            throw new NotImplementedException();
        }




    }
}