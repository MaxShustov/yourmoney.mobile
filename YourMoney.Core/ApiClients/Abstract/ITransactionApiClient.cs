using System.Collections.Generic;
using System.Threading.Tasks;
using YourMoney.Core.Models;

namespace YourMoney.Core.ApiClients.Abstract
{
    public interface ITransactionApiClient
    {
        Task AddTransaction(Transaction transaction);

        Task<IEnumerable<Transaction>> GetTransactions();

        Task<decimal> GetTotalSum();
    }
}