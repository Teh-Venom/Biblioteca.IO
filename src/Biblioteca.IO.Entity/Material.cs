using System.ComponentModel;

namespace Biblioteca.IO.Entity
{
    public abstract class Material : Core.Entity<Material>
    {

        public string Titulo { get; protected set; }

        public Assunto Assunto { get; protected set; }

        public Editora Editora { get; protected set; }


        public abstract override bool Valido();
    }
}