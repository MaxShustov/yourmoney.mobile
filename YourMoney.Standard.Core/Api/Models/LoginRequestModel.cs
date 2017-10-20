using Newtonsoft.Json;

namespace YourMoney.Standard.Core.Api.Models
{
    public class LoginRequestModel
    {
        public string UserName { get; set; }
        
        public string Password { get; set; }
    }
}