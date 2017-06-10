using System;
using Plugin.Settings.Abstractions;
using YourMoney.Core.Services.Abstract;

namespace YourMoney.Core.Services.Implementation
{
    public class SettingService : ISettingService
    {
        private const string UserIdKey = "UserIdKey";

        private ISettings _settings;

        public SettingService(ISettings settings)
        {
            _settings = settings;
        }

        public Guid UserId
        {
            get
            {
                return _settings.GetValueOrDefault<Guid>(UserIdKey);
            }
            set
            {
                _settings.AddOrUpdateValue(UserIdKey, value);
            }
        }


    }
}