﻿using System;
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
            //validação classe mãe material
            RuleFor(x => x.Assunto)
                .NotEmpty().WithMessage("Assunto não pode ser vazio!")
            RuleFor(x => x.Editora)
                .NotEmpty().WithMessage("Editora não pode estar vazia!");
            RuleFor(x => x.Titulo)
                .NotEmpty().WithMessage("Titulo não pode estar vazio!")
                .Length(1, 25).WithMessage("Tamanho do tituo deve estar entre 1 e 25 caracteres!");
            RuleFor(x => x.DataCadastro)
                .NotEmpty().WithMessage("Erro em coletar data atual! consulte o programador mais próximo.")
                .LessThanOrEqualTo(DateTime.Now).WithMessage("Erro em coletar data atual!(Data futura)");

            //validação classe filha revista
            RuleFor(y => Colecao)
                .NotEmpty().WithMessage("Coleção não pode estar vazio!")
                .Length(1, 25).WithMessage("Tamanho da coleção deve estar entre 1 e 25 caracteres!");
            RuleFor(y => Artigos)
                .NotEmpty().WithMessage("Deve existir pelo menos um artigo associado à revista!");
           

            ValidationResult = Validate(this);
        }
        //validado
    }
}