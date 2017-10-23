using Newtonsoft.Json;

namespace YourMoney.Standard.Core.Api.Models
{
    public class LoginRequestModel
    {
        [JsonProperty("userName")]
        public string UserName { get; }
        
        [JsonProperty("password")]
        public string Password { get; }

        public LoginRequestModel(string userName, string password)
        {
            UserName = userName;
            Password = password;
        }
    }
}