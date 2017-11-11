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
            RuleFor(x => x.DataCadastro)
                .NotEmpty().WithErrorCode("Erro em coletar data atual! consulte o programador mais próximo.")
                .LessThanOrEqualTo(DateTime.Now).WithErrorCode("Erro em coletar data atual!(Data futura)");
        }
    }
}