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
        public Endereco(DateTime dataCadastro, string logradouro, string bairro, string cep, int numero, string complemento, Cidade cidade)
        {
            DataCadastro = dataCadastro;
            Logradouro = logradouro;
            Bairro = bairro;
            Cep = cep;
            Numero = numero;
            Complemento = complemento;
            Cidade = cidade;
        }

        public Endereco(int id, DateTime dataCadastro, string logradouro, string bairro, string cep, int numero, string complemento, Cidade cidade)
        {
            Id = id;
            DataCadastro = dataCadastro;
            Logradouro = logradouro;
            Bairro = bairro;
            Cep = cep;
            Numero = numero;
            Complemento = complemento;
            Cidade = cidade;
        }

        public Endereco(DateTime dataCadastro, string logradouro, string bairro, string cep, int numero, string complemento)
        {
            DataCadastro = dataCadastro;
            Logradouro = logradouro;
            Bairro = bairro;
            Cep = cep;
            Numero = numero;
            Complemento = complemento;
        }

        public Endereco(int id, DateTime dataCadastro, string logradouro, string bairro, string cep, int numero, string complemento)
        {
            Id = id;
            DataCadastro = dataCadastro;
            Logradouro = logradouro;
            Bairro = bairro;
            Cep = cep;
            Numero = numero;
            Complemento = complemento;
        }

        #endregion
        //pronto com atribuir cidade.

        public override bool Valido()
        {
            Validacao();
            return ValidationResult.IsValid;
        }

        private void Validacao()
        {
            RuleFor(x => x.Logradouro)
                .NotEmpty().WithMessage("Logradouro não deve estar vazio.")
                .Length(1, 150).WithMessage("Logradouro deve conter entre 1 e 150 caracteres!");
            RuleFor(x => x.Bairro)
                .NotEmpty().WithMessage("Bairro não deve estar vazio.")
                .Length(1, 25).WithMessage("Bairro deve conter entre 1 e 25 caracteres!");
            RuleFor(x => x.Cep)
                .NotEmpty().WithMessage("CEP não deve estar vazio.")
                .Length(1, 12).WithMessage("CEP deve conter entre 1 e 12 caracteres!");
            RuleFor(x => x.Numero)
                .NotEmpty().WithMessage("Numero não deve estar vazio.");

            RuleFor(x => x.Complemento)
                .NotEmpty().WithMessage("Complemento não deve estar vazio.")
                .Length(1, 15).WithMessage("Complemento deve conter entre 1 e 15 caracteres!");
            RuleFor(x => x.Cidade)
                .NotEmpty().WithMessage("Deve estar associado à uma cidade.");
            RuleFor(x => x.DataCadastro)
                .NotEmpty().WithMessage("Erro em coletar data atual! consulte o programador mais próximo.")
                .LessThanOrEqualTo(DateTime.Now).WithMessage("Erro em coletar data atual!(Data futura)");

            ValidationResult = Validate(this);
        }
        //validado
    }
}