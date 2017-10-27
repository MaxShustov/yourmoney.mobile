using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using YourMoney.Standard.Core.Entities;

namespace YourMoney.Standard.Core.ApiClients.Abstract
{
    public interface IBaseApiClient<TEntity, in TKey>
        where TEntity: class, IBaseEnitity<TKey>
        where TKey: IEquatable<TKey>
    {
        Task<TEntity> GetAsync(TKey key);

        Task<IEnumerable<TEntity>> GetAsync(DateTime? updatedDate = null);

        Task AddAsync(TEntity entity);

        Task UpdateAsync(TEntity entity);

        Task DeleteAsync(TEntity entity);
    }
}