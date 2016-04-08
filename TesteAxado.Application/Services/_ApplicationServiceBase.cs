using TesteAxado.Application.Interfaces;
using TesteAxado.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;

namespace TesteAxado.Application.Services
{
    public class ApplicationServiceBase<TEntity> : IDisposable, IApplicationServiceBase<TEntity> where TEntity : class
    {
        private readonly IServiceBase<TEntity> _serviceBase;

        public ApplicationServiceBase(IServiceBase<TEntity> serviceBase)
        {
            _serviceBase = serviceBase;
        }

        public virtual void Add(TEntity item)
        {
            _serviceBase.Add(item);
        }
        public void Update(TEntity item)
        {
            _serviceBase.Update(item);
        }
        public void Remove(TEntity item)
        {
            _serviceBase.Remove(item);
        }

        public TEntity GetById(long id)
        {
            return _serviceBase.GetById(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _serviceBase.GetAll();
        }

        public void Dispose()
        {
            _serviceBase.Dispose();
        }
    }
}
