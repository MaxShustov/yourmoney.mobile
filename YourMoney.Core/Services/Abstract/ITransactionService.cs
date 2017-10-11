using System.Collections.Generic;
using System.Threading.Tasks;
using YourMoney.Core.Models;

namespace YourMoney.Core.Services.Abstract
{
    public interface ITransactionService
    {
        Task AddTransaction(Transaction transaction);

        Task<IEnumerable<Transaction>> GetTransactions();

        Task<decimal> GetTotalSum();
    }
}