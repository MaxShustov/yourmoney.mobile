using System.Threading.Tasks;
using YourMoney.Core.Models;

namespace YourMoney.Core.Services.Abstract
{
    public interface ITransactionService
    {
        Task AddTransaction(Transaction transaction);
    }
}