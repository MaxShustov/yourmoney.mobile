using System;

namespace YourMoney.Standard.Core.Services.Abstract
{
    public interface ISettingService
    {
        string Token { get; set; }

        DateTime LastUpdateTime { get; set; }
    }
}