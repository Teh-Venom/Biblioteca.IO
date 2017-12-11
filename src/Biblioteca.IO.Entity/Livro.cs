using System;
using System.Collections.Generic;
using FluentValidation;

namespace Biblioteca.IO.Entity
{
    public class Livro : Material
    {

        public string Edicao { get; private set; }

        public string Isbn { get; private set; }

        public List<Autor> Autores { get; private set; }


        #region Construtores

        public Livro(int id, DateTime dataCadastro, string titulo, int assunto, int editora, string edicao, string isbn, List<int> idAutores)
        {
            Id = id;
            DataCadastro = dataCadastro;
            Titulo = titulo;
            Assunto = Assunto.AssuntoFactory.Criar(idAssunto);
            Editora = Editora.EditoraFactory.Criar(idEditora);
            Edicao = edicao;
            Isbn = isbn;
            foreach (var x in idAutores)
            {
                Autores.Add(Autor.AutorFactory.Criar(x));
            }
        }

        private Livro()
        {

        }

        #endregion
        //pronto com atribuir assunto e editora da classe mãe Material.

        #region AdHoc Setter

        public void AtribuirAutor(Autor autores)
        {
            if (autores.Id.Equals(null)) return;
            Autores.Add(autores);
        }

        public void AtribuirListaAutor(List<Autor> autores)
        {
            if (autores.Equals(null)) return;
            foreach (var x in autores)
            {
                Autores.Add(x);
            }
        }

        public override void AtribuirAssunto(Assunto assunto)
        {
            if (assunto.Id.Equals(null)) return;
            Assunto = assunto;
        }

        public override void AtribuirEditora(Editora editora)
        {
            if (editora.Id.Equals(null)) return;
            Editora = editora;
        }


        #endregion
        //terminado métodos classe entity

        #region Validacao
        public override bool Valido()
        {
            Validacao();
            return ValidationResult.IsValid;
        }

        private void Validacao()
        {
            //validação classe mãe material
            RuleFor(x => x.Assunto)
                .NotEmpty().WithMessage("Assunto não pode ser vazio!");
            RuleFor(x => x.Editora)
                .NotEmpty().WithMessage("Editora não pode estar vazia!");
            RuleFor(x => x.Titulo)
                .NotEmpty().WithMessage("Titulo não pode estar vazio!")
                .Length(1, 25).WithMessage("Tamanho do tituo deve estar entre 1 e 25 caracteres!");
            RuleFor(x => x.DataCadastro)
                .NotEmpty().WithMessage("Erro em coletar data atual! consulte o programador mais próximo.")
                .LessThanOrEqualTo(DateTime.Now).WithMessage("Erro em coletar data atual!(Data futura)");

            //Validação classe filha Livro
            RuleFor(x => Edicao)
                .NotEmpty().WithMessage("Edição não deve estar vazia!")
                .Length(1, 10).WithMessage("Edição deve ter entre 1 e 10 caracteres!");
            RuleFor(x => Isbn)
                .NotEmpty().WithMessage("ISBN não deve estar vazia!")
                .Length(1, 15).WithMessage("ISBN deve ter entre 1 e 15 caracteres!");
            RuleFor(x => Autores)
                .NotEmpty().WithMessage("Deve haver pelo menos um autor associado!");

            ValidationResult = Validate(this);
        }
        //validado
        #endregion
    }
}