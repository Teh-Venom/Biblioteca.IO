using System;
using FluentValidation;

namespace Biblioteca.IO.Entity
{
    public class Cidade : Core.Entity<Cidade>
    {
        public string Nome { get; private set; }

        public Estado Estado { get; private set; }


        #region Construtores



        #endregion


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