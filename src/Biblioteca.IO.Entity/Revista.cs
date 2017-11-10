using System;
using System.Collections.Generic;
using FluentValidation;

namespace Biblioteca.IO.Entity
{
    public class Revista : Material
    {

        public string Colecao { get; private set; }

        public List<Artigo> Artigos { get; private set; }

        #region Construtores
        public Revista(int id, DateTime dataCadastro, string colecao, List<Artigo> artigos)
        {
            Id = id;
            DataCadastro = dataCadastro;
            Colecao = colecao;
            Artigos = artigos;
        }

        public Revista(DateTime dataCadastro, string colecao, List<Artigo> artigos)
        {
            DataCadastro = dataCadastro;
            Colecao = colecao;
            Artigos = artigos;
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