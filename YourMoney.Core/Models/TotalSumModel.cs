using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace YourMoney.Core.Models
{
    public class TotalSumModel: BaseResponseModel
    {
        public decimal TotalSum { get; set; }
    }
}