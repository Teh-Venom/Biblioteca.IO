using System;
using FluentValidation;

namespace Biblioteca.IO.Entity
{
    public class Assunto : Core.Entity<Assunto>
    {
        
        public string Nome { get; private set; }


        #region Construtores
        public Assunto(int id, DateTime dataCadastro, string nome)
        {
            Id = id;
            DataCadastro = dataCadastro;
            Nome = nome;
        }

        public Assunto(DateTime dataCadastro, string nome)
        {
            DataCadastro = dataCadastro;
            Nome = nome;
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