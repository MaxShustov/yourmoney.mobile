using Newtonsoft.Json;

namespace YourMoney.Core.Models
{
    public class LoginResponseModel
    {
        [JsonProperty("UserId")]
        public string UserId { get; set; }
    }
}