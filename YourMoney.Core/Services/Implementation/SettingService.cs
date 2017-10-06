using Plugin.Settings.Abstractions;
using YourMoney.Core.Services.Abstract;

namespace YourMoney.Core.Services.Implementation
{
    public class SettingService : ISettingService
    {
        private const string TokenKey = "TokenKey";

        private readonly ISettings _settings;

        public SettingService(ISettings settings)
        {
            _settings = settings;
        }

        public string Token
        {
            get
            {
                return _settings.GetValueOrDefault<string>(TokenKey);
            }
            set
            {
                _settings.AddOrUpdateValue(TokenKey, value);
            }
        }


    }
}