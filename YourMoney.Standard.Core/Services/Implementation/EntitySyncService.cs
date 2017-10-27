using System;
using System.Collections.Generic;
using System.Linq;
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
        where TKey: IEquatable<TKey>
    {
        private readonly IGenericRepository<TEntity, TKey> _entityRepository;
        private readonly IBaseApiClient<TEntity, TKey> _apiClient;
        private readonly ISettingService _settingService;

        public EntitySyncService(IGenericRepository<TEntity, TKey> entityRepository, IBaseApiClient<TEntity, TKey> apiClient, ISettingService settingService)
        {
            _entityRepository = entityRepository;
            _apiClient = apiClient;
            _settingService = settingService;
        }

        public async Task Sync()
        {
            var lastSyncDate = _settingService.LastUpdateTime;
            
            var localEntities = await _entityRepository
                .Filter(e => e.SyncState != EntitySyncState.Synced)
                .ToListAsync();

            var updatedRemoteEntities = (await _apiClient.GetAsync(lastSyncDate)).ToList();

            var entitiesToInsert = updatedRemoteEntities.Where(re => localEntities.All(e => !e.Id.Equals(re.Id)));
            var entitiesToUpdate = updatedRemoteEntities.Where(re => localEntities.Any(e => e.SyncState != EntitySyncState.Deleted && e.Id.Equals(re.Id)));

            using (var transaction = _entityRepository.BeginTransaction())
            {
                try
                {
                    foreach (var entity in entitiesToInsert)
                    {
                        await _entityRepository.AddAsync(entity);
                    }

                    foreach (var entity in entitiesToUpdate)
                    {
                        await _entityRepository.UpdateAsync(entity);
                    }

                    foreach (var entity in localEntities.Where(e => e.SyncState == EntitySyncState.Added))
                    {
                        await _apiClient.AddAsync(entity);
                    }

                    foreach (var entity in localEntities.Where(e => e.SyncState == EntitySyncState.Deleted))
                    {
                        await _apiClient.AddAsync(entity);
                    }

                    foreach (var entity in localEntities.Where(e => e.SyncState == EntitySyncState.Deleted))
                    {
                        await _apiClient.DeleteAsync(entity);
                    }

                    foreach (var localEntity in localEntities)
                    {
                        localEntity.SyncState = EntitySyncState.Synced;

                        await _entityRepository.UpdateAsync(localEntity);
                    }

                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();

                    //TODO Log exception
                }
            }
            
            _settingService.LastUpdateTime = DateTime.UtcNow;
        }

        private IEnumerable<TEntity> GetEntitiesToInsert(IEnumerable<TEntity> localEntities, IEnumerable<TEntity> entities)
        {
            return localEntities.Except(entities);
        }
    }
}