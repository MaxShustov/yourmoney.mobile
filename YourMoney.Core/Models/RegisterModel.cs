using Newtonsoft.Json;

namespace YourMoney.Core.Models
{
    public class RegisterModel
    {
        [JsonProperty("userName")]
        public string UserName { get; set; }

        [JsonProperty("password")]
        public string Password { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }
    }
}