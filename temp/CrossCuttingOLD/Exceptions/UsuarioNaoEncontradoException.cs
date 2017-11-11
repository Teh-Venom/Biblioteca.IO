using System;

namespace Biblioteca.IO.CrossCutting.Exceptions
{
    public class UsuarioNaoEncontradoException : Exception
    {
        public UsuarioNaoEncontradoException() : this("O usuario não foi encontrado")
        {

        }

        public UsuarioNaoEncontradoException (string mensagem) 
            : base(mensagem)
        {
            
        }

        public UsuarioNaoEncontradoException(string mensagem, Exception innerException) 
            : base(mensagem, innerException)
        {

        }
    }
}