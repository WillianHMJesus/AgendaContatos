using System.Collections.Generic;
using System.Collections.ObjectModel;
using TrabalhoUWP.Abstract;
using TrabalhoUWP.Interface;

namespace TrabalhoUWP.Repository
{
    public abstract class RepositoryBase<T> : NotifyableClass, IRepository<T> where T : class
    {
        private ObservableCollection<T> _items = new ObservableCollection<T>();
        public ObservableCollection<T> Items
        {
            protected set { Set(ref _items, value); }
            get { return _items; }
        }

        public abstract List<T> CarregarTodos();
        public abstract void Inserir(T entity);
        public abstract void Atualizar(T entity);
        public abstract void Excluir(T entity);
        public abstract T CarregarPorID(int ID);
    }
}
