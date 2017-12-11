using System;
using System.Collections.Generic;
using FluentValidation;

namespace Biblioteca.IO.Entity
{
    public class Revista : Material
    {

        public string Colecao { get; private set; }

        public List<Artigo> Artigos { get; private set; }

        #region Construtores

        public Revista(int id, DateTime dataCadastro, string titulo, Assunto assunto, Editora editora, string colecao, List<int> idArtigos)
        {
            Id = id;
            DataCadastro = dataCadastro;
            Titulo = titulo;
            Assunto = assunto;
            Editora = editora;
            Colecao = colecao;
            foreach (var x in idArtigos)
            {
                Artigos.Add(Artigo.ArtigoFactory.Criar(x));
            }
        }

        private Revista()
        {

        }

        #endregion
        //pronto para atribuir artigo (assunto e editora fazendo parte do atribuir da classe material), não tem esse metodo no diagrama de classe
        //mas faz sentido, pois não há metodo para construir revista nele, de qualquer modo.

        #region AdHoc Setter

        public void AtribuirArtigo(Artigo artigo)
        {
            if (artigo.Id.Equals(null)) return;
            Artigos.Add(artigo);
        }

        public void AtribuirListaArtigo(List<Artigo> artigos)
        {
            if (artigos.Equals(null)) return;
            foreach (var x in artigos)
            {
                Artigos.Add(x);
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

        //terminado métodos para classe entity

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

            //validação classe filha revista
            RuleFor(y => Colecao)
                .NotEmpty().WithMessage("Coleção não pode estar vazio!")
                .Length(1, 25).WithMessage("Tamanho da coleção deve estar entre 1 e 25 caracteres!");
            RuleFor(y => Artigos)
                .NotEmpty().WithMessage("Deve existir pelo menos um artigo associado à revista!");
           

            ValidationResult = Validate(this);
        }
        //validado
    }
}