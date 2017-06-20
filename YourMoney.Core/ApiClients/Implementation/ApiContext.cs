using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using ModernHttpClient;
using Newtonsoft.Json;
using YourMoney.Core.ApiClients.Abstract;
using YourMoney.Core.Exceptions;
using YourMoney.Core.Helpers;
using YourMoney.Core.Models;

namespace YourMoney.Core.ApiClients.Implementation
{
    public class ApiContext : IApiContext
    {
        private readonly HttpClient _httpClient;

        public ApiContext()
        {
            _httpClient = new HttpClient(new NativeMessageHandler());
            _httpClient.BaseAddress = new Uri(AppConfig.Url);
        }

        public async Task<string> Login(string url, LoginModel loginModel)
        {
            var response = await Post<LoginResponseModel, LoginModel>(url, loginModel);

            return response.UserId;
        }

        public async Task<T> Get<T>(string url)
        {
            var result = await _httpClient.GetAsync(url);

            CheckIfOk(result);

            return await result.Get<T>();
        }

        public async Task<TResult> Post<TResult, TContent>(string url, TContent content)
        {
            var json = JsonConvert.SerializeObject(content);
            var result = await _httpClient.PostAsync(url, new StringContent(json, Encoding.Unicode, "application/json"));

            CheckIfOk(result);

            return await result.Get<TResult>();
        }

        public async Task Post<TContent>(string url, TContent content)
        {
            var json = JsonConvert.SerializeObject(content);

            var res = await _httpClient.PostAsync(url, new StringContent(json, Encoding.Unicode, "application/json"));

            CheckIfOk(res);
        }

        public Task Put<T>(string url, T content)
        {
            throw new System.NotImplementedException();
        }

        public Task Delete(string url)
        {
            throw new System.NotImplementedException();
        }

        private void CheckIfOk(HttpResponseMessage httpResponseMessage)
        {
            if (!httpResponseMessage.IsSuccessStatusCode)
            {
                if (httpResponseMessage.StatusCode == HttpStatusCode.Forbidden)
                {
                    throw new ForbiddenApiException();
                }

                throw new ApiException(httpResponseMessage.StatusCode);
            }
        }
    }
}