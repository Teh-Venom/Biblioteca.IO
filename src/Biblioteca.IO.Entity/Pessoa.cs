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

        public Pessoa(int id, DateTime dataCadastro ,string nome, string rg, string cpf, List<int> idTelefones, int idEndereco)
        {
            Id = id;
            DataCadastro = dataCadastro;
            Nome = nome;
            Rg = rg;
            Cpf = cpf;
            foreach (var x in idTelefones)
            {
                Telefones.Add(Telefone.TelefoneFactory.Criar(x));
            }
            Endereco = Endereco.EnderecoFactory.Criar(idEndereco);
        }

        private Pessoa()
        {

        }

        #endregion
        //pronto, de acordo com atribuir endereco e telefone

        #region AdHoc Setter

        public void AtribuirTelefones(Telefone telefones)
        {
            if (telefones.Id.Equals(null)) return;
            Telefones.Add(telefones);
        }

        public void AtribuirListaArtigo(List<Telefone> telefones)
        {
            if (telefones.Equals(null)) return;
            foreach (var x in telefones)
            {
                Telefones.Add(x);
            }
        }

        public void AtribuirEndereco(Endereco endereco)
        {
            if (endereco.Id.Equals(null)) return;
            Endereco = endereco;
        }

        public void CadastrarPessoa(string nome, string rg, string cpf)
        {
            Nome = nome;
            Rg = rg;
            Cpf = cpf;  
        }

        #endregion
        //terminado métodos para classe entity

        #region Factory

        public static class PessoaFactory
        {
            public static Pessoa Criar(int id)
            {
                var pessoa = new Pessoa();
                pessoa.Id = id;
                return pessoa;
            }

            public static Pessoa Criar(string nome)
            {
                var pessoa = new Pessoa();
                pessoa.Nome = nome;
                return pessoa;
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
                .Length(1, 50).WithMessage("Nome deve conter entre 1 e 50 caracteres.");
            RuleFor(x => x.Rg)
                .NotEmpty().WithMessage("RG  não pode estar vazio!")
                .Length(1, 14).WithMessage("RG deve conter entre 1 e 14 caracteres.");
            RuleFor(x => x.Cpf)
                .NotEmpty().WithMessage("CPF  não pode estar vazio!")
                .Length(1, 15).WithMessage("CPF deve conter entre 1 e 15 caracteres.");
            RuleFor(x => x.Telefones)
                .NotEmpty().WithMessage("Deve haver no mínimu um telefone associado!");
            RuleFor(x => x.Endereco)
                .NotEmpty().WithMessage("Deve haver um endereço associado!");
            RuleFor(x => x.DataCadastro)
                .NotEmpty().WithMessage("Erro em coletar data atual! consulte o programador mais próximo.")
                .LessThanOrEqualTo(DateTime.Now).WithMessage("Erro em coletar data atual!(Data futura)");
            ValidationResult = Validate(this);
        }
        //validado
    }
}