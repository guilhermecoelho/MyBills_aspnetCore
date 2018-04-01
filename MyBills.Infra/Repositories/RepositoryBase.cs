using MongoDB.Bson;
using MongoDB.Driver.Builders;
using MyBills.Domain.Repositories;
using MyBills.Infra.IoC;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyBills.Infra.Repositories
{
    public abstract class EntityBase
    {
        public Guid Id { get; set; }
    }

    public class RepositoryBase<TEntity> : IDisposable, IRepositoryBase<TEntity> where TEntity : class
    {
        DataAccess dataAccess = new DataAccess();

        private readonly string _collection;

        public RepositoryBase(string collection)
        {
            _collection = collection;
        }

        public virtual async Task<TEntity> Add(TEntity obj)
        {
            await Task.Run(() => dataAccess.db.GetCollection<TEntity>(_collection).Insert(obj));

            return obj;
        }

        public virtual async Task<IEnumerable<TEntity>> GetAll()
        {
            return await Task.Run(() => dataAccess.db.GetCollection<TEntity>(_collection).FindAll());
        }

        public virtual async Task<TEntity> GetById(string id)
        {
            return await Task.Run(() => dataAccess.db.GetCollection<TEntity>(_collection).FindOneById(ObjectId.Parse(id)));
        }

        public void Remove(string id)
        {
            dataAccess.db.GetCollection<TEntity>(_collection).Remove(Query.EQ("_id", ObjectId.Parse(id)));
        }

        public void Update(string id, TEntity entity)
        {
            dataAccess.db.GetCollection<TEntity>(_collection).Update(Query.EQ("_id", ObjectId.Parse(id)), Update<TEntity>.Replace(entity));
        }

        public void Dispose()
        {

        }
    }
}
