using System;

namespace Biblioteca.IO.CrossCutting.Exceptions
{
    public class UsuarioExistenteException: Exception
    {
        public UsuarioExistenteException()
        {

        }

        public UsuarioExistenteException (string mensagem) 
            : base(mensagem)
        {
            
        }

        public UsuarioExistenteException(string mensagem, Exception innerException) 
            : base(mensagem, innerException)
        {

        }
    }
}