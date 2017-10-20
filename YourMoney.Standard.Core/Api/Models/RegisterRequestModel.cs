using Newtonsoft.Json;

namespace YourMoney.Standard.Core.Api.Models
{
    public class RegisterRequestModel
    {
        public string UserName { get; }
        
        public string Password { get; }
        
        public string Email { get; }

        public RegisterRequestModel(string userName, string password, string email)
        {
            UserName = userName;
            Password = password;
            Email = email;
        }
    }
}