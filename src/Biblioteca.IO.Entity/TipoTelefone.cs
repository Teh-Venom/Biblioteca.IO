﻿using System;
using FluentValidation;

namespace Biblioteca.IO.Entity
{
    public class TipoTelefone : Core.Entity<TipoTelefone>
    {
        public string Nome { get; private set; }

        #region Construtores

        public TipoTelefone(int id, DateTime dataCadastro, string nome)
        {
            Id = id;
            DataCadastro = dataCadastro;
            Nome = nome;
        }

        private TipoTelefone()
        {

        }

        #endregion
        //pronto
        #region Factory

        public static class TipoTelefoneFactory
        {
            public static TipoTelefone Criar(int id)
            {
                var tipoTelefone = new TipoTelefone();
                tipoTelefone.Id = id;
                return tipoTelefone;
            }

            public static TipoTelefone Criar(string nome)
            {
                var tipoTelefone = new TipoTelefone();
                tipoTelefone.Nome = nome;
                return tipoTelefone;
            }
        }

        #endregion
        //não há metodos para classe entity

        public override bool Valido()
        {
            Validacao();
            return ValidationResult.IsValid;
        }

        private void Validacao()
        {
            RuleFor(x => x.Nome)
                .NotEmpty().WithMessage("Nome não deve ser Vazio")
                .Length(1, 15).WithMessage("Nome deve conter entre 1 e 15 caracteres");
            RuleFor(x => x.DataCadastro)
                .NotEmpty().WithMessage("Erro em coletar data atual! consulte o programador mais próximo.")
                .LessThanOrEqualTo(DateTime.Now).WithMessage("Erro em coletar data atual!(Data futura)");

            ValidationResult = Validate(this);
        }
        //validado
    }
}