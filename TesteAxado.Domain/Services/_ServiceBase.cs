using TesteAxado.Domain.Interfaces.Repositories;
using TesteAxado.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;

namespace TesteAxado.Domain.Services
{
    public class ServiceBase<TEntity> : IDisposable, IServiceBase<TEntity> where TEntity : class
    {
        private readonly IRepositoryBase<TEntity> _repository;

        public ServiceBase(IRepositoryBase<TEntity> repository)
        {
            _repository = repository;
        }

        public void Add(TEntity item)
        {
            _repository.Add(item);
        }
        public void Update(TEntity item)
        {
            _repository.Update(item);
        }

        public void Remove(TEntity item)
        {
            _repository.Remove(item);
        }

        public TEntity GetById(long id)
        {
            return _repository.GetById(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _repository.GetAll();
        }

        public void Dispose()
        {
            _repository.Dispose();
        }
    }
}
