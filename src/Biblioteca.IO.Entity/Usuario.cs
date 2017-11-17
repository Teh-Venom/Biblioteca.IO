using System;
using FluentValidation;
using FluentValidation.Results;

namespace Biblioteca.IO.Entity
{
    public class Usuario : Core.Entity<Usuario>
    {
        public string Email { get; private set; }

        public string Senha { get; private set; }

        public Pessoa Pessoa { get; private set; }

        #region Construtores

        public Usuario(DateTime dataCadastro, string email, string senha, Pessoa pessoa)
        {
            DataCadastro = dataCadastro;
            Email = email;
            Senha = senha;
            Pessoa = pessoa;
        }

        public Usuario(int id, DateTime dataCadastro, string email, string senha, Pessoa pessoa)
        {
            Id = id;
            DataCadastro = dataCadastro;
            Email = email;
            Senha = senha;
            Pessoa = pessoa;
        }

        public Usuario(int id, DateTime dataCadastro, string email, string senha)
        {
            Id = id;
            DataCadastro = dataCadastro;
            Email = email;
            Senha = senha;
        }

        public Usuario(DateTime dataCadastro, string email, string senha)
        {
            DataCadastro = dataCadastro;
            Email = email;
            Senha = senha;

        }

        #endregion


        #region AdHoc Setter

        public void AtribuirSenha(string senha)
        {
            if (string.IsNullOrWhiteSpace(senha)) return;

            Senha = senha;
        }

        public void AtribuirPessoa(Pessoa pessoa)
        {
            if (Pessoa.Id.Equals(null)) return;

            Pessoa = pessoa;
        }

        #endregion

        //Terminado métodos da classe entity.


        public override bool Valido()
        {
            Validar();
            return ValidationResult.IsValid;
        }

        private void Validar()
        {
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email não deve ser Vazio")
                .Length(5, 150).WithMessage("Email deve conter entre 5 e 150 caracteres");
            RuleFor(x => x.Senha)
                .NotNull().WithMessage("Senha é obrigatoria")
                .Length(99).WithMessage("Senha deve conter 99 caracteres");
            RuleFor(x => x.Pessoa)
                .NotNull().WithMessage("Obrigatório atribuir pessoa");
            RuleFor(x => x.DataCadastro)
                .NotEmpty().WithMessage("Erro em coletar data atual! consulte o programador mais próximo.")
                .LessThanOrEqualTo(DateTime.Now).WithMessage("Erro em coletar data atual!(Data futura)");

            ValidationResult = Validate(this);
        }
        //validado
    }
}