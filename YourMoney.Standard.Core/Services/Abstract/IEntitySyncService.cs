using System.Threading.Tasks;
using YourMoney.Standard.Core.Entities;

namespace YourMoney.Standard.Core.Services.Abstract
{
    public interface IEntitySyncService<TEntity, TKey>
        where TEntity: class, IBaseEnitity<TKey>
    {
        Task Sync();
    }
}