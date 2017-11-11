using System.ComponentModel;

namespace Biblioteca.IO.Entity
{
    public abstract class Material : Core.Entity<Material>
    {

        public string Titulo { get; protected set; }

        public Assunto Assunto { get; protected set; }

        public Editora Editora { get; protected set; }

        //não há construtor por ser método abstrato, somente livro/revista poderá usar esses atributos.
        //nas classes filhas os construtores utilizam destes atributos.

        public abstract override bool Valido();
    }
}