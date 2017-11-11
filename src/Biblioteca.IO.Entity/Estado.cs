using System;
using FluentValidation;

namespace Biblioteca.IO.Entity
{
    public class Estado : Core.Entity<Estado>
    {
        
        public string Nome { get; private set; }

        public string Sigla { get; private set; }


        #region Construtores

        public Estado(DateTime dataCadastro, string sigla, string nome)
        {
            DataCadastro = dataCadastro;
            Sigla = sigla;
            Nome = nome;
        }

        public Estado(int id, DateTime dataCadastro, string sigla, string nome)
        {
            Id = id;
            DataCadastro = dataCadastro;
            Sigla = sigla;
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