using System;
using FluentValidation;

namespace Biblioteca.IO.Entity
{
    public class Endereco : Core.Entity<Endereco>
    {

        public string Logradouro { get; private set; }

        public string Bairro { get; private set; }

        public string Cep { get; private set; }

        public int Numero { get; private set; }

        public string Complemento { get; private set; }

        public Cidade Cidade { get; private set; }


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