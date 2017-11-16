﻿using System;
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
            //validação classe mãe material
            RuleFor(x => x.Assunto)
                .NotEmpty().WithMessage("Assunto não pode ser vazio!");
            RuleFor(x => x.Editora)
                .NotEmpty().WithErrorCode("Editora não pode estar vazia!");
            RuleFor(x => x.Titulo)
                .NotEmpty().WithErrorCode("Titulo não pode estar vazio!")
                .Length(1, 25).WithErrorCode("Tamanho do tituo deve estar entre 1 e 25 caracteres!");
            RuleFor(x => x.DataCadastro)
                .NotEmpty().WithErrorCode("Erro em coletar data atual! consulte o programador mais próximo.")
                .LessThanOrEqualTo(DateTime.Now).WithErrorCode("Erro em coletar data atual!(Data futura)");

            //Validação classe filha Livro
            RuleFor(x => Edicao)
                .NotEmpty().WithErrorCode("Edição não deve estar vazia!")
                .Length(1, 10).WithErrorCode("Edição deve ter entre 1 e 10 caracteres!");
            RuleFor(x => Isbn)
                .NotEmpty().WithErrorCode("ISBN não deve estar vazia!")
                .Length(1, 15).WithErrorCode("ISBN deve ter entre 1 e 15 caracteres!");
            RuleFor(x => Autores)
                .NotEmpty().WithErrorCode("Deve haver pelo menos um autor associado!");

            ValidationResult = Validate(this);
        }
        //validado
    }
}