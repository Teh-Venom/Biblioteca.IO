using System;
using FluentValidation;

namespace Biblioteca.IO.Entity
{
    public class Editora : Core.Entity<Editora>
    {
        

        public string Nome { get; private set; }


        #region Construtores

        public Editora(int id, DateTime dataCadastro, string nome)
        {
            Id = id;
            DataCadastro = dataCadastro;
            Nome = nome;
        }

        public Editora(DateTime dataCadastro, string nome)
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