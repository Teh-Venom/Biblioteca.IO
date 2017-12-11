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

        private Editora()
        {

        }

        #endregion
        //pronto

        #region Factory

        public static class EditoraFactory
        {
            public static Editora Criar(int id)
            {
                var editora = new Editora();
                editora.Id = id;
                return editora;
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