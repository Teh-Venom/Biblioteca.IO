using System;
using FluentValidation;

namespace Biblioteca.IO.Entity
{
    public class Estado : Core.Entity<Estado>
    {
        
        public string Nome { get; private set; }

        public string Sigla { get; private set; }


        #region Construtores

        public Estado(int id, DateTime dataCadastro, string sigla, string nome)
        {
            Id = id;
            DataCadastro = dataCadastro;
            Sigla = sigla;
            Nome = nome;
        }

        private Estado()
        {

        }

        #endregion
        //pronto
        #region Factory

        public static class EstadoFactory
        {
            public static Estado Criar(int id)
            {
                var estado = new Estado();
                estado.Id = id;
                return estado;
            }

            public static Estado Criar(string nome)
            {
                var estado = new Estado();
                estado.Nome = nome;
                return estado;
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
            RuleFor(x => x.Nome)
                .NotEmpty().WithMessage("Nome não deve ser Vazio")
                .Length(1, 25).WithMessage("Nome deve conter entre 1 e 25 caracteres");
            RuleFor(x => x.Sigla)
                .NotEmpty().WithMessage("Sigla não deve ser Vazio")
                .Length(1, 2).WithMessage("Nome deve conter entre 1 e 2 caracteres");
            RuleFor(x => x.DataCadastro)
                .NotEmpty().WithMessage("Erro em coletar data atual! consulte o programador mais próximo.")
                .LessThanOrEqualTo(DateTime.Now).WithMessage("Erro em coletar data atual!(Data futura)");

            ValidationResult = Validate(this);
        }
        //validado
    }
}