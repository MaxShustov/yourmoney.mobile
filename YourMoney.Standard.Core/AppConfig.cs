namespace YourMoney.Standard.Core
{
    public class AppConfig
    {
        public const string BaseUrl = "https://your-money-api.herokuapp.com";
        //public const string BaseUrl = "http://localhost:53467";

        public static readonly string ApiUrl = $"{BaseUrl}/api";
    }
}