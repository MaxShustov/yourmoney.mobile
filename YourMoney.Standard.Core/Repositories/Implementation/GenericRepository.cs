using System;
using System.Linq;
using System.Linq.Expressions;
using System.Reactive.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using YourMoney.Standard.Core.Entities;
using YourMoney.Standard.Core.Repositories.Abstract;

namespace YourMoney.Standard.Core.Repositories.Implementation
{
    public class GenericRepository<TEntity, TKey> : IGenericRepository<TEntity, TKey>
        where TEntity : class, IBaseEnitity<TKey>
        where TKey: IEquatable<TKey>
    {
        protected readonly TransactionsDbContext Context;
        protected readonly DbSet<TEntity> Entities;

        public GenericRepository(TransactionsDbContext context)
        {
            Context = context;
            Entities = Context.Set<TEntity>();
        }

        public Task<TEntity> GetByIdAsync(TKey key)
        {
            return Entities.FindAsync(key);
        }

        public TEntity GetById(TKey key)
        {
            return Entities.Find(key);
        }

        public Task AddAsync(TEntity entity)
        {
            return Entities.AddAsync(entity);
        }

        public void Add(TEntity entity)
        {
            Entities.Add(entity);
        }

        public Task UpdateAsync(TEntity entity)
        {
            Entities.Update(entity);

            return Task.CompletedTask;
        }

        public void Update(TEntity entity)
        {
            Entities.Update(entity);
        }

        public Task DeleteAsync(TEntity entity)
        {
            Entities.Remove(entity);

            return Task.CompletedTask;
        }

        public void Delete(TEntity entity)
        {
            Entities.Remove(entity);
        }

        public async Task DeleteAsync(TKey key)
        {
            var entity = await GetByIdAsync(key);

            Delete(entity);
        }

        public void Delete(TKey key)
        {
            var entity = GetById(key);

            Delete(entity);
        }

        public IQueryable<TEntity> Filter(Expression<Func<TEntity, bool>> expression)
        {
            return Entities.AsNoTracking().Where(expression);
        }

        public IQueryable<TEntity> GetAll()
        {
            return Entities.AsNoTracking();
        }

        public IDbContextTransaction BeginTransaction()
        {
            return Context.Database.BeginTransaction();
        }
    }
}