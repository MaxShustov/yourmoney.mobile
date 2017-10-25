using System;
using System.Linq;
using System.Linq.Expressions;
using System.Reactive.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Storage;
using YourMoney.Standard.Core.Entities;

namespace YourMoney.Standard.Core.Repositories.Abstract
{
    public interface IGenericRepository<TEntity, in TKey>
        where TEntity : class, IBaseEnitity<TKey>
    {
        Task<TEntity> GetByIdAsync(TKey key);
        TEntity GetById(TKey key);
        Task AddAsync(TEntity entity);
        void Add(TEntity entity);
        Task UpdateAsync(TEntity entity);
        void Update(TEntity entity);
        Task DeleteAsync(TEntity entity);
        void Delete(TEntity entity);
        Task DeleteAsync(TKey key);
        void Delete(TKey key);
        IQueryable<TEntity> Filter(Expression<Func<TEntity, bool>> expression);
        IQueryable<TEntity> GetAll();
        IDbContextTransaction BeginTransaction();
    }
}