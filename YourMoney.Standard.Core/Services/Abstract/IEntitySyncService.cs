using System;
using System.Threading.Tasks;
using YourMoney.Standard.Core.Entities;

namespace YourMoney.Standard.Core.Services.Abstract
{
    public interface IEntitySyncService<TEntity, TKey>
        where TEntity: class, IBaseEnitity<TKey>
        where TKey: IEquatable<TKey>
    {
        Task Sync();
    }
}