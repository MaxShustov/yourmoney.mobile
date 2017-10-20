using System.Collections.Generic;
using System.Threading.Tasks;
using YourMoney.Standard.Core.Api.Models;

namespace YourMoney.Standard.Core.Services.Abstract
{
    public interface ITransactionService
    {
        Task AddTransaction(TransactionModel transaction);

        Task<IEnumerable<TransactionModel>> GetTransactions();

        Task<decimal> GetTotalSum();
    }
}