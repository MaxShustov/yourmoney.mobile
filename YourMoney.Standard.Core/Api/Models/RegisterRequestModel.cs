using Newtonsoft.Json;

namespace YourMoney.Standard.Core.Api.Models
{
    public class RegisterRequestModel
    {
        [JsonProperty("userName")]
        public string UserName { get; }
        
        [JsonProperty("password")]
        public string Password { get; }
        
        [JsonProperty("email")]
        public string Email { get; }

        public RegisterRequestModel(string userName, string password, string email)
        {
            UserName = userName;
            Password = password;
            Email = email;
        }
    }
}