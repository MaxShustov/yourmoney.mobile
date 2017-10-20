using Newtonsoft.Json;

namespace YourMoney.Standard.Core.Api.Models
{
    public class LoginRequestModel
    {
        public string UserName { get; }
        
        public string Password { get; }

        public LoginRequestModel(string userName, string password)
        {
            UserName = userName;
            Password = password;
        }
    }
}