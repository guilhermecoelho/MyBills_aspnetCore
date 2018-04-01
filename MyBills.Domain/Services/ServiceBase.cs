using MyBills.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyBills.Domain.Services
{
    public class ServiceBase<TEntity> : IDisposable, IServiceBase<TEntity> where TEntity : class
    {
        public readonly IRepositoryBase<TEntity> _repository;

        public ServiceBase(IRepositoryBase<TEntity> repository)
        {
            this._repository = repository;
        }

        public async Task<TEntity> Add(TEntity obj)
        {
            await _repository.Add(obj);

            return obj;
        }

        public async Task<IEnumerable<TEntity>> GetAll()
        {
            return await _repository.GetAll();
        }

        public async Task<TEntity> GetById(string id)
        {
            return await _repository.GetById(id);
        }

        public void Remove(string id)
        {
            _repository.Remove(id);
        }

        public void Update(string id, TEntity entity)
        {
            _repository.Update(id, entity);
        }

        public void Dispose()
        {
            _repository.Dispose();
        }
    }
}
