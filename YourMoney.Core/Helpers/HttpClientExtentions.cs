using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace YourMoney.Core.Helpers
{
    public static class HttpClientExtentions
    {
        public static async Task<T> Get<T>(this HttpResponseMessage message)
        {
            var json = await message.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<T>(json);
        }
    }
}