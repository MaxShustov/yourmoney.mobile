using System;
using System.Collections.Generic;
using System.Diagnostics;
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
                .ToListAsync()
                .ConfigureAwait(false);

            var updatedRemoteEntities = (await _apiClient.GetAsync(lastSyncDate).ConfigureAwait(false)).ToList();

            var entitiesToInsert = updatedRemoteEntities.Where(re => localEntities.All(e => !e.Id.Equals(re.Id)));
            var entitiesToUpdate = updatedRemoteEntities.Where(re => localEntities.Any(e => e.SyncState != EntitySyncState.Deleted && e.Id.Equals(re.Id)));

            using (var transaction = _entityRepository.BeginTransaction())
            {
                try
                {
                    var updateLocalTask = UpdateLocalEntities(
                        entitiesToInsert,
                        entitiesToUpdate,
                        Enumerable.Empty<TEntity>());

                    var updateRemoteTask = UpdateRemoteEntities(
                        localEntities.Where(e => e.SyncState == EntitySyncState.Added),
                        localEntities.Where(e => e.SyncState == EntitySyncState.Updated),
                        localEntities.Where(e => e.SyncState == EntitySyncState.Deleted));

                    await Task.WhenAll(updateLocalTask, updateRemoteTask)
                        .ConfigureAwait(false);

                    await Task.WhenAll(
                        localEntities.Select(e =>
                        {
                            e.SyncState = EntitySyncState.Synced;

                            return e;
                        })
                        .Select(e => _entityRepository.UpdateAsync(e)))
                        .ConfigureAwait(false);

                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();

                    //TODO Log exception
                    Debug.WriteLine(ex.Message);
                }
            }
            
            _settingService.LastUpdateTime = DateTime.UtcNow;
        }

        private Task UpdateLocalEntities(IEnumerable<TEntity> toInsert, IEnumerable<TEntity> toUpdate, IEnumerable<TEntity> toDelete)
        {
            var insertTasks = toInsert.Select(e => _entityRepository.AddAsync(e));
            var updateTasks = toUpdate.Select(e => _entityRepository.UpdateAsync(e));
            var deleteTasks = toDelete.Select(e => _entityRepository.DeleteAsync(e));

            return Task.WhenAll(insertTasks.Concat(updateTasks).Concat(deleteTasks));
        }

        private Task UpdateRemoteEntities(IEnumerable<TEntity> toAdd, IEnumerable<TEntity> toUpdate, IEnumerable<TEntity> toDelete)
        {
            var addTasks = toAdd.Select(e => _apiClient.AddAsync(e));
            var updateTasks = toUpdate.Select(e => _apiClient.UpdateAsync(e));
            var deleteTasks = toDelete.Select(e => _apiClient.DeleteAsync(e));

            return Task.WhenAll(addTasks.Concat(updateTasks).Concat(deleteTasks));
        }
    }
}