using Newtonsoft.Json;

namespace YourMoney.Core.Models
{
    public class LoginResponseModel: BaseResponseModel
    {
        public string Token { get; set; }
    }
}