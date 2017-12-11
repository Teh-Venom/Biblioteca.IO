using System;
using FluentValidation;

namespace Biblioteca.IO.Entity
{
    public class Cidade : Core.Entity<Cidade>
    {
        public string Nome { get; private set; }

        public Estado Estado { get; private set; }


        #region Construtores

        public Cidade(int id, DateTime dataCadastro, string nome, int idEstado) 
        {
            Id = id;
            DataCadastro = dataCadastro;
            Nome = nome;
            Estado = Estado.EstadoFactory.Criar(idEstado);
        }

        private Cidade()
        {

        }

        #endregion
        //pronto com atribuir estado.

        #region AdHoc Setter

        public void AtribuirEstado(Estado estado) //TODO validar objeto antes de settar
        {
            if (!estado.Valido()) return;

            Estado = estado;
        }

        #endregion
        //terminaod métodos classe entity

        #region Factory

        public static class CidadeFactory
        {
            public static Cidade Criar(int id)
            {
                var cidade = new Cidade();
                cidade.Id = id;
                return cidade;
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
                .NotEmpty().WithMessage("Nome não pode estar vazio!")
                .Length(1, 50).WithMessage("Nome deve ter entre 1 e 50 caracteres!");
            RuleFor(x => x.Estado)
                .NotEmpty().WithMessage("Deve haver um estado associado!");
            RuleFor(x => x.DataCadastro)
                .NotEmpty().WithMessage("Erro em coletar data atual! consulte o programador mais próximo.")
                .LessThanOrEqualTo(DateTime.Now).WithMessage("Erro em coletar data atual!(Data futura)");
            
            ValidationResult = Validate(this);

            ValidarEstado(); 
        }

        private void ValidarEstado() 
        {
            if (Estado.Valido()) return;

            foreach (var error in Estado.ValidationResult.Errors)
            {
                ValidationResult.Errors.Add(error);
            }


        }
    }
}