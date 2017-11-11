using System;

namespace Biblioteca.IO.CrossCutting.Exceptions
{
    public class ErroInternoDoServidorExeption: Exception
    {
        public ErroInternoDoServidorExeption()
        {

        }

        public ErroInternoDoServidorExeption (string mensagem) 
            : base(mensagem)
        {
            
        }

        public ErroInternoDoServidorExeption(string mensagem, Exception innerException) 
            : base(mensagem, innerException)
        {

        }
    }
}