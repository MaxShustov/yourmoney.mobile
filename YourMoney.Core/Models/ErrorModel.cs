using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace YourMoney.Core.Models
{
    public class ErrorModel
    {
        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("code")]
        public int Code { get; set; }
    }
}