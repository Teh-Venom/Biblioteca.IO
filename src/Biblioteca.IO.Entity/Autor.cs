using System;
using FluentValidation;

namespace Biblioteca.IO.Entity
{
    public class Autor : Core.Entity<Autor>
    {
        
        public string Nome { get; private set; }

        public string Email { get; private set; }


        #region Construtores

        public Autor(int id, DateTime dataCadastro, string nome, string email)
        {
            Id = id;
            DataCadastro = dataCadastro;
            Nome = nome;
            Email = email;
        }

        public Autor(DateTime dataCadastro, string nome, string email)
        {
            DataCadastro = dataCadastro;
            Nome = nome;
            Email = email;
        }

        #endregion
        //pronto

        public override bool Valido()
        {
            Validacao();
            return ValidationResult.IsValid;
        }

        private void Validacao()
        {
            RuleFor(x => x.DataCadastro)
                .NotEmpty().WithErrorCode("Erro em coletar data atual! consulte o programador mais próximo.")
                .LessThanOrEqualTo(DateTime.Now).WithErrorCode("Erro em coletar data atual!(Data futura)");
        }
    }
}