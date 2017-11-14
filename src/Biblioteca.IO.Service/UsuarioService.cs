using System;
using Biblioteca.IO.CrossCutting;
using Biblioteca.IO.CrossCutting.Helpers;
using Biblioteca.IO.Entity;
using Biblioteca.IO.Repository.Interfaces;
using Biblioteca.IO.Service.Interfaces;

namespace Biblioteca.IO.Service
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            if (usuarioRepository == null)
                throw new ArgumentNullException();

            _usuarioRepository = usuarioRepository;
        }
        
        
        public void CadastrarUsuario(Usuario usuario)
        {
            //if (usuario.Valido())
                //aggregate exception, pesquisar
            //TODO: Validar usuario 
            var _usuarioExistente = _usuarioRepository.VerificarUsuarioExistente(usuario.Email);
            if (_usuarioExistente)
            {
                throw new UsuarioExistenteException();
            }

            usuario.AtribuirSenha(usuario.Senha.ToHash());

            _usuarioRepository.Inserir(usuario);
        }
    }
}