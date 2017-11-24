using System;
using System.Collections.Generic;
using Biblioteca.IO.Entity;

namespace Biblioteca.IO.Repository.Interfaces
{
    public interface IEmprestimoRepository
    {
        void RealizarEmprestimo(Emprestimo emprestimo);

        void RealizarDevolucao(DateTime dataRetorno);

        List<Emprestimo> ObterPorUsuario(Usuario usuario);

        List<Emprestimo> ObterPorDataPrevistaRetorno(DateTime dataPrevistaRetorno);

        List<Emprestimo> ObterPorEmprestimosAtrasados(DateTime dataInicial, DateTime dataFinal); //??? obtem usando oq menino
    }
}