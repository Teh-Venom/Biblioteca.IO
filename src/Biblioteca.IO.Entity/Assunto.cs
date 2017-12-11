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

        private Assunto()
        {

        }

        #endregion
        //pronto

        #region Factory

        public static class AssuntoFactory
        {
            public static Assunto Criar(int id)
            {
                var assunto = new Assunto();
                assunto.Id = id;
                return assunto;
            }

        }

        #endregion

        public override bool Valido()
        {
            Validacao();
            return ValidationResult.IsValid;
        }

        private void Validacao()
        {
            RuleFor(x => x.Nome)
                .NotEmpty().WithMessage("Nome não pode estar vazio!")
                .Length(1, 50).WithMessage("Nome deve ter entre 1 e 50 caracteres!");
            RuleFor(x => x.DataCadastro)
                .NotEmpty().WithMessage("Erro em coletar data atual! consulte o programador mais próximo.")
                .LessThanOrEqualTo(DateTime.Now).WithMessage("Erro em coletar data atual!(Data futura)");
            ValidationResult = Validate(this);
        }
        //validado
    }
}