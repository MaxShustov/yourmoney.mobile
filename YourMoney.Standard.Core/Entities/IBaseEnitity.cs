using System;
using YourMoney.Standard.Core.Enums;

namespace YourMoney.Standard.Core.Entities
{
    public interface IBaseEnitity<TKey>
        where TKey: IEquatable<TKey>
    {
        TKey Id { get; set; }

        EntitySyncState SyncState { get; set; }

        DateTime UpdateDate { get; set; }
    }
}