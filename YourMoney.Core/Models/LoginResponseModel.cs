using System;
using Newtonsoft.Json;

namespace YourMoney.Core.Models
{
    public class LoginResponseModel
    {
        [JsonProperty("UserId")]
        public Guid UserId { get; set; }
    }
}