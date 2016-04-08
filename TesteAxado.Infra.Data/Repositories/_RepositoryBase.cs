using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using TesteAxado.Domain.Interfaces.Repositories;
using TesteAxado.Infra.Data.Context;

namespace TesteAxado.Infra.Data.Repositories
{
    public class RepositoryBase<TEntity> : IDisposable, IRepositoryBase<TEntity> where TEntity : class
    {
        protected TesteAxadoContext Db = new TesteAxadoContext();

        public void Add(TEntity item)
        {
            Db.Set<TEntity>().Add(item);
            Db.SaveChanges();
        }
        public void Update(TEntity item)
        {
            Db.Entry(item).State = EntityState.Modified;
            Db.SaveChanges();
        }

        public void Remove(TEntity item)
        {
            Db.Set<TEntity>().Remove(item);
            Db.SaveChanges();
        }

        public TEntity GetById(long id)
        {
            return Db.Set<TEntity>().Find(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return Db.Set<TEntity>().ToList();
        }

        public void Dispose()
        {
       
        }
    }
}
