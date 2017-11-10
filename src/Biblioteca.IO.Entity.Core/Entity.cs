using System;
using FluentValidation;
using FluentValidation.Results;

namespace Biblioteca.IO.Entity.Core
{
    public abstract class Entity<T> : AbstractValidator<T> where T: Entity<T>
    {
        public int Id { get; protected set; }

        public DateTime DataCadastro { get; protected set; }

        public ValidationResult ValidationResult { get; protected set; }

        protected Entity() //Aplicação pendente, verificar
        {
            ValidationResult = new ValidationResult();
        }
        
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(this, obj))
                return true;

            if (ReferenceEquals(null, obj))
                return false;

            var entity = obj as Entity<T>;

            return entity != null && entity.Id == Id;
        }

        public override int GetHashCode()
        {
            return GetType().GetHashCode() * 999 + Id.GetHashCode();
        }

        public abstract bool Valido();
    }
}