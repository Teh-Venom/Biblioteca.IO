using System;
using System.Collections.Generic;
using FluentValidation;

namespace Biblioteca.IO.Entity
{
    public class Reserva : Core.Entity<Reserva>
    {
       

        public DateTime DataReserva { get; private set; }

        public DateTime DataValidade { get; private set; }

        public List<Material> Materiais { get; private set; }

        public Usuario Usuario { get; private set; }


        #region Construtores
        public Reserva(int id, DateTime dataCadastro, DateTime dataReserva, DateTime dataValidade, List<Material> materiais, Usuario usuario)
        {
            Id = id;
            DataCadastro = dataCadastro;
            DataReserva = dataReserva;
            DataValidade = dataValidade;
            Materiais = materiais;
            Usuario = usuario;
        }
        public Reserva(DateTime dataCadastro, DateTime dataReserva, DateTime dataValidade, List<Material> materiais, Usuario usuario)
        {
            DataCadastro = dataCadastro;
            DataReserva = dataReserva;
            DataValidade = dataValidade;
            Materiais = materiais;
            Usuario = usuario;
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
            RuleFor(x => x.DataReserva)
                .NotEmpty().WithErrorCode("Data Reserva não pode estar vazia!")
                .GreaterThan(DateTime.Now).WithErrorCode("Data reserva deve ser maior que a data atual.");
            RuleFor(x => DataValidade)
                .NotEmpty().WithErrorCode("Data Validade não pode estar vazia!");
            RuleFor(x => x.Materiais)
                .NotEmpty().WithErrorCode("Material não pode estar vazio!");
            RuleFor(x => x.Usuario)
                .NotEmpty().WithErrorCode("Usuario não pode estar vazio!");
            RuleFor(x => x.DataCadastro)
                .NotEmpty().WithErrorCode("Erro em coletar data atual! consulte o programador mais próximo.")
                .LessThanOrEqualTo(DateTime.Now).WithErrorCode("Erro em coletar data atual!(Data futura)");

            ValidationResult = Validate(this);
        }
        //validado
    }
}