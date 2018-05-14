using System.Collections.Generic;
using System.Threading.Tasks;
using YourMoney.Standard.Core.Api.Models;
using System.Reactive;
using System;

namespace YourMoney.Standard.Core.Services.Abstract
{
    public interface ITransactionService
    {
        IObservable<Unit> AddTransaction(TransactionModel transaction);

        IObservable<IEnumerable<TransactionModel>> GetTransactions();

        IObservable<decimal> GetTotalSum();
    }
}