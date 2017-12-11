using System;

namespace Biblioteca.IO.CrossCutting
{
    public class UsuarioExistenteException : Exception
    {
        public UsuarioExistenteException() : this("O usuario já existe.")
        {
            
        }

        public UsuarioExistenteException(string message) : base(message)
        {

        }
    }
}