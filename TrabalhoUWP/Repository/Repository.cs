using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace TrabalhoUWP.Repository
{
    public class Repository<T> : RepositoryBase<T> where T : class
    {
        AppDbContext db = new AppDbContext();

        public override void Atualizar(T entity)
        {
            db.Entry(entity).State = EntityState.Modified;
            db.SaveChanges();
        }

        public override T CarregarPorID(int ID)
        {
            return db.Set<T>().Find(ID);
        }

        public override List<T> CarregarTodos()
        {
            return db.Set<T>().ToList();
        }

        public override void Excluir(T entity)
        {
            db.Set<T>().Remove(entity);
            db.SaveChanges();
        }

        public override void Inserir(T entity)
        {
            db.Set<T>().Add(entity);
            db.SaveChanges();
        }
    }
}
