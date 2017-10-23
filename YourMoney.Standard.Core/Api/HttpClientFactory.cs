using System;
using System.Net.Http;
using YourMoney.Standard.Core.Services.Abstract;

namespace YourMoney.Standard.Core.Api
{
    public class HttpClientFactory
    {
        public static HttpClient GetHttpClient(ISettingService settingService)
        {
            return new HttpClient(new AuthHttpClientHandler(settingService))
            {
                BaseAddress = new Uri(AppConfig.ApiUrl)
            };
        }
    }
}