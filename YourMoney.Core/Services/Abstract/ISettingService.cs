using System;

namespace YourMoney.Core.Services.Abstract
{
    public interface ISettingService
    {
        Guid UserId { get; set; }
    }
}