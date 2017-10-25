using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using YourMoney.Standard.Core.ApiClients.Abstract;
using YourMoney.Standard.Core.Entities;
using YourMoney.Standard.Core.Enums;
using YourMoney.Standard.Core.Repositories.Abstract;
using YourMoney.Standard.Core.Services.Abstract;

namespace YourMoney.Standard.Core.Services.Implementation
{
    public class EntitySyncService<TEntity, TKey>: IEntitySyncService<TEntity, TKey>
        where TEntity : class, IBaseEnitity<TKey>
    {
        private readonly IGenericRepository<TEntity, TKey> _entityRepository;
        private readonly IBaseApiClient<TEntity, TKey> _apiClient;

        public EntitySyncService(IGenericRepository<TEntity, TKey> entityRepository, IBaseApiClient<TEntity, TKey> apiClient)
        {
            _entityRepository = entityRepository;
            _apiClient = apiClient;
        }

        public async Task Sync()
        {
            var localEntities = await _entityRepository
                .Filter(e => e.SyncState != EntitySyncState.Synced)
                .ToListAsync();

            var entities = await _apiClient.GetAsync();
        }
    }
}