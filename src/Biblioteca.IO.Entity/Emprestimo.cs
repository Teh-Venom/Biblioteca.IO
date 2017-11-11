using System;
using System.Collections.Generic;
using FluentValidation;

namespace Biblioteca.IO.Entity
{
    public class Emprestimo : Core.Entity<Emprestimo>
    {
        

        public DateTime DataEmprestimo { get; private set; }

        public DateTime DataPrevistaRetorno { get; private set; }

        public DateTime DataRetorno { get; private set; }

        public List<Material> Materiais { get; private set; }

        public Usuario Usuario { get; private set; }


        #region Construtores
        public Emprestimo(DateTime dataCadastro, DateTime dataEmprestimo, DateTime dataPrevistaRetorno, DateTime dataRetorno, List<Material> materiais, Usuario usuario)
        {
            DataCadastro = dataCadastro;
            DataEmprestimo = dataEmprestimo;
            DataPrevistaRetorno = dataPrevistaRetorno;
            DataRetorno = dataRetorno;
            Materiais = materiais;
            Usuario = usuario;
        }

        public Emprestimo(int id, DateTime dataCadastro, DateTime dataEmprestimo, DateTime dataPrevistaRetorno, DateTime dataRetorno, List<Material> materiais, Usuario usuario)
        {
            Id = id;
            DataCadastro = dataCadastro;
            DataEmprestimo = dataEmprestimo;
            DataPrevistaRetorno = dataPrevistaRetorno;
            DataRetorno = dataRetorno;
            Materiais = materiais;
            Usuario = usuario;
        }

        public Emprestimo(DateTime dataCadastro, DateTime dataEmprestimo, DateTime dataPrevistaRetorno, List<Material> materiais, Usuario usuario)
        {
            DataCadastro = dataCadastro;
            DataEmprestimo = dataEmprestimo;
            DataPrevistaRetorno = dataPrevistaRetorno;
            Materiais = materiais;
            Usuario = usuario;
        }

        public Emprestimo(int id, DateTime dataCadastro, DateTime dataEmprestimo, DateTime dataPrevistaRetorno, List<Material> materiais, Usuario usuario)
        {
            Id = id;
            DataCadastro = dataCadastro;
            DataEmprestimo = dataEmprestimo;
            DataPrevistaRetorno = dataPrevistaRetorno;
            Materiais = materiais;
            Usuario = usuario;
        }


        #endregion
        //pronto com atribuir DataRetorno.

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