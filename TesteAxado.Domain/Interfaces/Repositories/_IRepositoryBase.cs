﻿using System.Collections.Generic;

namespace TesteAxado.Domain.Interfaces.Repositories
{
    public interface IRepositoryBase<TEntity> where TEntity : class
    {
        void Add(TEntity item);
        void Update(TEntity item);
        void Remove(TEntity item);

        TEntity GetById(long id);
        IEnumerable<TEntity> GetAll();

        void Dispose();
    }
}
