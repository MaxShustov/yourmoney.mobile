using YourMoney.Standard.Core.Entities;

namespace YourMoney.Standard.Core.ApiClients.Abstract
{
    public interface ITransactionsApiClient: IBaseApiClient<Transaction, string>
    {
    }
}