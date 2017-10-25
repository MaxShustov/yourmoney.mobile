using System.Threading.Tasks;
using YourMoney.Standard.Core.Entities;

namespace YourMoney.Standard.Core.Repositories.Abstract
{
    public interface ITransactionsRepository: IGenericRepository<Transaction, string>
    {
    }
}