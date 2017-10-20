using System.Collections.Generic;
using System.Threading.Tasks;
using Refit;
using YourMoney.Standard.Core.Api.Models;

namespace YourMoney.Standard.Core.Api.Interfaces
{
    public interface ITransactionsApi
    {
        [Get("/transactions")]
        Task<IEnumerable<TransactionModel>> GetTransactions();

        [Post("/transactions")]
        Task CreateTransaction(TransactionModel transaction);

        [Get("/transactions/summary")]
        Task<TotalSumResponseModel> GetTotalSum();
    }
}