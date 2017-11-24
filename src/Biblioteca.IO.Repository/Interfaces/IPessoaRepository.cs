using Biblioteca.IO.Entity;

namespace Biblioteca.IO.Repository.Interfaces
{
    public interface IPessoaRepository
    {
        void CadastrarPessoa(Pessoa pessoa);

        Pessoa ObterPorId(int id);

        void AtualizarEndereco(Pessoa pessoa);

        void AtualizarTelefone(Pessoa pessoa);

        void AtualizarPessoa(Pessoa pessoa);
    }
}