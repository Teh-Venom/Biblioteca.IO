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
        public Artigo(int id, DateTime dataCadastro, string titulo, List<Autor> autores)
        {
            Id = id;
            DataCadastro = dataCadastro;
            Titulo = titulo;
            Autores = autores;
        }

        public Artigo(DateTime dataCadastro, string titulo, List<Autor> autores)
        {
            DataCadastro = dataCadastro;
            Titulo = titulo;
            Autores = autores;
        }

        #endregion
        //pronto
        
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