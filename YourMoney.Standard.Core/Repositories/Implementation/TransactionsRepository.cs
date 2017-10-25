using YourMoney.Standard.Core.Entities;
using YourMoney.Standard.Core.Repositories.Abstract;

namespace YourMoney.Standard.Core.Repositories.Implementation
{
    public class TransactionsRepository: GenericRepository<Transaction, string>, ITransactionsRepository
    {
        public TransactionsRepository(TransactionsDbContext context)
            : base(context)
        {
        }
    }
}