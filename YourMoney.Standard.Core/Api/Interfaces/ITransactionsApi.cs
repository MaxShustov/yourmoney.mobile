using System.Collections.Generic;
using System.Threading.Tasks;
using Refit;
using YourMoney.Standard.Core.Api.Models;
using System;
using System.Reactive;

namespace YourMoney.Standard.Core.Api.Interfaces
{
    [Headers("Authorization: JWT")]
    public interface ITransactionsApi
    {
        [Get("/transactions")]
        IObservable<IEnumerable<TransactionModel>> GetTransactions();

        [Post("/transactions")]
        IObservable<Unit> CreateTransaction(TransactionModel transaction);

        [Get("/transactions/summary")]
        IObservable<TotalSumResponseModel> GetTotalSum();
    }
}