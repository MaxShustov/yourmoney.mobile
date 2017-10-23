using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using YourMoney.Standard.Core.Services.Abstract;

namespace YourMoney.Standard.Core.Api
{
    public class AuthHttpClientHandler: HttpClientHandler
    {
        private readonly ISettingService _settingService;

        public AuthHttpClientHandler(ISettingService settingService)
        {
            _settingService = settingService;
        }

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var auth = request.Headers.Authorization;

            if (auth != null  && !string.IsNullOrEmpty(_settingService.Token))
            {
                request.Headers.Authorization = new AuthenticationHeaderValue(auth.Scheme, _settingService.Token);
            }

            return base.SendAsync(request, cancellationToken);
        }
    }
}