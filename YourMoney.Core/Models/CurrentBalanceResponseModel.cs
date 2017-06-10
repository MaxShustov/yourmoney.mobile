using Newtonsoft.Json;

namespace YourMoney.Core.Models
{
    public class CurrentBalanceResponseModel
    {
        [JsonProperty("currentBalance")]
        public decimal CurrentBalance { get; set; }
    }
}