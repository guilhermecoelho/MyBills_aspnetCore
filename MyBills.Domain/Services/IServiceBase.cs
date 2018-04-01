using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyBills.Domain.Services
{
    public interface IServiceBase<TEntity> where TEntity : class
    {
        Task<TEntity> Add(TEntity obj);
        Task<TEntity> GetById(string id);
        Task<IEnumerable<TEntity>> GetAll();
        void Update(string id, TEntity entity);
        void Remove(string id);
        void Dispose();
    }
}
