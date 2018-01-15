using System.Collections.Generic;

namespace TrabalhoUWP.Interface
{
    interface IRepository<T>
    {
        List<T> CarregarTodos();
        T CarregarPorID(int ID);
        void Inserir(T entity);
        void Atualizar(T entity);
        void Excluir(T entity);
    }
}
