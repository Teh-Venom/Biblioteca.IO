using System;
using FluentValidation;

namespace Biblioteca.IO.Entity
{
    public class Cidade : Core.Entity<Cidade>
    {
        public string Nome { get; private set; }

        public Estado Estado { get; private set; }


        #region Construtores

        public Cidade(int id, DateTime dataCadastro, string nome, Estado estado)
        {
            Id = id;
            DataCadastro = dataCadastro;
            Nome = nome;
            Estado = estado;
        }

        public Cidade(DateTime dataCadastro, string nome, Estado estado)
        {
            DataCadastro = dataCadastro;
            Nome = nome;
            Estado = estado;
        }

        public Cidade(int id, DateTime dataCadastro, string nome)
        {
            Id = id;
            DataCadastro = dataCadastro;
            Nome = nome;
        }

        public Cidade(DateTime dataCadastro, string nome)
        {
            DataCadastro = dataCadastro;
            Nome = nome;
        }

        #endregion
        //pronto com atribuir estado.

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