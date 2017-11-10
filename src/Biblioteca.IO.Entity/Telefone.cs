using System;
using FluentValidation;

namespace Biblioteca.IO.Entity
{
    public class Telefone : Core.Entity<Telefone>
    {
        

        public int IdPessoa { get; private set; }

        public string Numero { get; private set; }

        public TipoTelefone TipoTelefone { get; private set; }

        #region Construtores
        public Telefone(DateTime dataCadastro, int idPessoa, string numero, TipoTelefone tipoTelefone)
        {
            DataCadastro = dataCadastro;
            IdPessoa = idPessoa;
            Numero = numero;
            TipoTelefone = tipoTelefone;
        }

        public Telefone(int id, DateTime dataCadastro, int idPessoa, string numero, TipoTelefone tipoTelefone)
        {
            Id = id;
            DataCadastro = dataCadastro;
            IdPessoa = idPessoa;
            Numero = numero;
            TipoTelefone = tipoTelefone;
        }

        #endregion

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