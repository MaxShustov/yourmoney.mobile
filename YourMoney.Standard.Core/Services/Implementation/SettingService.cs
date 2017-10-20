using Plugin.Settings.Abstractions;
using YourMoney.Standard.Core.Services.Abstract;

namespace YourMoney.Standard.Core.Services.Implementation
{
    public class SettingService : ISettingService
    {
        private readonly ISettings _settings;

        public SettingService(ISettings settings)
        {
            _settings = settings;
        }

        public string Token
        {
            get
            {
                return _settings.GetValueOrDefault(nameof(Token), string.Empty);
            }
            set
            {
                _settings.AddOrUpdateValue(nameof(Token), value);
            }
        }

    }
}