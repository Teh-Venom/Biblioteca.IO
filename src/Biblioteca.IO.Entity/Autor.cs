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
            RuleFor(x => x.Nome)
                .NotEmpty().WithMessage("Nome não pode estar vazio!")
                .Length(1, 50).WithMessage("Nome deve ter entre 1 e 50 caracteres!");
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email não deve ser Vazio")
                .Length(5, 150).WithMessage("Email deve conter entre 5 e 150 caracteres");
            RuleFor(x => x.DataCadastro)
                .NotEmpty().WithMessage("Erro em coletar data atual! consulte o programador mais próximo.")
                .LessThanOrEqualTo(DateTime.Now).WithMessage("Erro em coletar data atual!(Data futura)");

            ValidationResult = Validate(this);
        }
        //validado
    }
}