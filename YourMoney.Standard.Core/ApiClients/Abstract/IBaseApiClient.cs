using System.Collections.Generic;
using System.Threading.Tasks;
using YourMoney.Standard.Core.Entities;

namespace YourMoney.Standard.Core.ApiClients.Abstract
{
    public interface IBaseApiClient<TEntity, in TKey>
        where TEntity: class, IBaseEnitity<TKey>
    {
        Task<TEntity> GetAsync(TKey key);

        Task<IEnumerable<TEntity>> GetAsync();

        Task AddAsync(TEntity entity);

        Task UpdateAsync(TEntity entity);

        Task DeleteAsync(TEntity entity);
    }
}