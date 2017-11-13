using System.Collections.Generic;

namespace Biblioteca.IO.Repository.Interfaces
{
    public interface ICrudRepository<T>
    {
        void Inserir(T obj);

        T Obter(int id);

        void Deletar(int id);

        void Atualizar(T obj);
    }
}