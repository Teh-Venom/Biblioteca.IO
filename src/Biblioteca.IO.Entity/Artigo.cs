using System;
using System.Collections.Generic;
using FluentValidation;

namespace Biblioteca.IO.Entity
{
    public class Artigo : Core.Entity<Artigo>
    {
        
        public string Titulo { get; private set; }

        public List<Autor> Autores { get; private set; }


        #region Construtores
        public Artigo(int id, DateTime dataCadastro, string titulo, List<int> idAutores)
        {
            Id = id;
            DataCadastro = dataCadastro;
            Titulo = titulo;
            foreach (var x in idAutores)
            {
                Autores.Add(Autor.AutorFactory.Criar(x));
            }
        }

        private Artigo()
        {

        }

        #endregion
        //pronto

        #region Factory

        public static class ArtigoFactory
        {
            public static Artigo Criar(int id)
            {
                var artigo = new Artigo();
                artigo.Id = id;
                return artigo;
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
            RuleFor(x => x.Titulo)
                .NotEmpty().WithMessage("Titulo não pode estar vazio!")
                .Length(1, 25).WithMessage("Tamanho do tituo deve estar entre 1 e 25 caracteres!");

            RuleFor(x => Autores)
                .NotEmpty().WithMessage("Deve haver pelo menos um autor associado!");

            RuleFor(x => x.DataCadastro)
                .NotEmpty().WithMessage("Erro em coletar data atual! consulte o programador mais próximo.")
                .LessThanOrEqualTo(DateTime.Now).WithMessage("Erro em coletar data atual!(Data futura)");

            ValidationResult = Validate(this);
        }
        //validado
    }
}