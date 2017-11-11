using System;
using System.Collections.Generic;
using FluentValidation;

namespace Biblioteca.IO.Entity
{
    public class Livro : Material
    {

        public string Edicao { get; private set; }

        public string Isbn { get; private set; }

        public List<Autor> Autores { get; private set; }


        #region Construtores

        public Livro(DateTime dataCadastro, string titulo, Assunto assunto, Editora editora, string edicao, string isbn, List<Autor> autores)
        {
            DataCadastro = dataCadastro;
            Titulo = titulo;
            Assunto = assunto;
            Editora = editora;
            Edicao = edicao;
            Isbn = isbn;
            Autores = autores;
        }

        public Livro(int id, DateTime dataCadastro, string titulo, Assunto assunto, Editora editora, string edicao, string isbn, List<Autor> autores)
        {
            Id = id;
            DataCadastro = dataCadastro;
            Titulo = titulo;
            Assunto = assunto;
            Editora = editora;
            Edicao = edicao;
            Isbn = isbn;
            Autores = autores;
        }

        public Livro(DateTime dataCadastro, string titulo, string edicao, string isbn, List<Autor> autores)
        {
            DataCadastro = dataCadastro;
            Titulo = titulo;
            Edicao = edicao;
            Isbn = isbn;
            Autores = autores;
        }

        public Livro(int id, DateTime dataCadastro, string titulo, string edicao, string isbn, List<Autor> autores)
        {
            Id = id;
            DataCadastro = dataCadastro;
            Titulo = titulo;
            Edicao = edicao;
            Isbn = isbn;
            Autores = autores;
        }

        #endregion
        //pronto com atribuir assunto e editora da classe mãe Material.

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