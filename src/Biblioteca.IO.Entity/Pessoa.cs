using System;
using System.Collections.Generic;
using FluentValidation;

namespace Biblioteca.IO.Entity
{
    public class Pessoa : Core.Entity<Pessoa>
    {
        

        public string Nome { get; private set; }

        public string Rg { get; private set; }

        public string Cpf { get; private set; }

        public List<Telefone> Telefones { get; private set; }

        public Endereco Endereco { get; private set; }


        #region Construtores

        public Pessoa(int id, DateTime dataCadastro ,string nome, string rg, string cpf, List<Telefone> telefones, Endereco endereco)
        {
            Id = id;
            DataCadastro = dataCadastro;
            Nome = nome;
            Rg = rg;
            Cpf = cpf;
            Telefones = telefones;
            Endereco = endereco;
        }

        public Pessoa(DateTime dataCadastro, string nome, string rg, string cpf, List<Telefone> telefones, Endereco endereco)
        {
            DataCadastro = dataCadastro;
            Nome = nome;
            Rg = rg;
            Cpf = cpf;
            Telefones = telefones;
            Endereco = endereco;
        }

        #endregion


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