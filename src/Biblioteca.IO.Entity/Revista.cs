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
        public Revista(int id, DateTime dataCadastro, string titulo, string colecao, List<Artigo> artigos)
        {
            Id = id;
            DataCadastro = dataCadastro;
            Titulo = titulo;
            Colecao = colecao;
            Artigos = artigos;
        }

        public Revista(DateTime dataCadastro, string titulo, string colecao, List<Artigo> artigos)
        {
            DataCadastro = dataCadastro;
            Titulo = titulo;
            Colecao = colecao;
            Artigos = artigos;
        }

        public Revista(int id, DateTime dataCadastro, string titulo, string colecao)
        {
            Id = id;
            DataCadastro = dataCadastro;
            Titulo = titulo;
            Colecao = colecao;
        }

        public Revista(DateTime dataCadastro, string titulo, string colecao)
        {
            DataCadastro = dataCadastro;
            Titulo = titulo;
            Colecao = colecao;
        }



        public Revista(int id, DateTime dataCadastro, string titulo, Assunto assunto, Editora editora, string colecao, List<Artigo> artigos)
        {
            Id = id;
            DataCadastro = dataCadastro;
            Titulo = titulo;
            Assunto = assunto;
            Editora = editora;
            Colecao = colecao;
            Artigos = artigos;
        }

        public Revista(DateTime dataCadastro, string titulo, Assunto assunto, Editora editora, string colecao, List<Artigo> artigos)
        {
            DataCadastro = dataCadastro;
            Titulo = titulo;
            Assunto = assunto;
            Editora = editora;
            Colecao = colecao;
            Artigos = artigos;
        }

        public Revista(int id, DateTime dataCadastro, string titulo, Assunto assunto, Editora editora, string colecao)
        {
            Id = id;
            DataCadastro = dataCadastro;
            Titulo = titulo;
            Assunto = assunto;
            Editora = editora;
            Colecao = colecao;
        }

        public Revista(DateTime dataCadastro, string titulo, Assunto assunto, Editora editora, string colecao)
        {
            DataCadastro = dataCadastro;
            Titulo = titulo;
            Assunto = assunto;
            Editora = editora;
            Colecao = colecao;
        }

        #endregion
        //pronto para atribuir artigo (assunto e editora fazendo parte do atribuir da classe material), não tem esse metodo no diagrama de classe
        //mas faz sentido, pois não há metodo para construir revista nele, de qualquer modo.
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