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

        //pronto para atribuir pessoa

        #region AdHoc Setter

        public void AtribuirSenha(string senha)
        {
            if (string.IsNullOrWhiteSpace(senha)) return;

            Senha = senha;
        }

        #endregion

        //ATRIBUIR PESSOA AQUI!:!!!?!?!?


        public override bool Valido()
        {
            Validar();
            return ValidationResult.IsValid;
        }

        private void Validar()
        {
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email não deve ser Vazio")
                .Length(9, 99).WithMessage("Nome deve conter entre 9 e 99 caracteres");
            RuleFor(x => x.Senha)
                .NotNull().WithMessage("Senha é obrigatoria")
                .Length(99).WithMessage("Senha deve conter 99 caracteres");
            RuleFor(x => x.Pessoa)
                .NotNull().WithMessage("Obrigatório atribuir pessoa");
            RuleFor(x => x.DataCadastro)
                .NotEmpty().WithErrorCode("Erro em coletar data atual! consulte o programador mais próximo.")
                .LessThanOrEqualTo(DateTime.Now).WithErrorCode("Erro em coletar data atual!(Data futura)");

            ValidationResult = Validate(this);
        }
    }
}