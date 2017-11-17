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

        public Telefone(DateTime dataCadastro, int idPessoa, string numero)
        {
            DataCadastro = dataCadastro;
            IdPessoa = idPessoa;
            Numero = numero;
        }

        public Telefone(int id, DateTime dataCadastro, int idPessoa, string numero)
        {
            Id = id;
            DataCadastro = dataCadastro;
            IdPessoa = idPessoa;
            Numero = numero;
        }


        #endregion
        //pronto, concluido para metodo atribuir tipotelefone

        #region AdHoc Setter

        public void AtribuirTipoTelefone(TipoTelefone tipoTelefone)
        {
            if (tipoTelefone.Id.Equals(null)) return;

            TipoTelefone = tipoTelefone;
        }


        #endregion
        //terminado métodos para classe entity

        public override bool Valido()
        {
            Validacao();
            return ValidationResult.IsValid;
        }

        private void Validacao()
        {
            RuleFor(x => x.IdPessoa)
                .NotEmpty().WithMessage("Deve ser associado à ID de uma pessoa.");
            RuleFor(x => x.Numero)
                .NotEmpty().WithMessage("Numero nao pode ser vazio.")
                .Length(1, 20).WithMessage("Numero deve ter entre 1 e 20 caracteres!");
            RuleFor(x => x.TipoTelefone)
                .NotEmpty().WithMessage("Tipo de telefone deve ser associado!");
            RuleFor(x => x.DataCadastro)
                .NotEmpty().WithMessage("Erro em coletar data atual! consulte o programador mais próximo.")
                .LessThanOrEqualTo(DateTime.Now).WithMessage("Erro em coletar data atual!(Data futura)");
            ValidationResult = Validate(this);
        }
        //validado
    }
}