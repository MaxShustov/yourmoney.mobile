using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Refit;
using YourMoney.Standard.Core.Api.Interfaces;
using YourMoney.Standard.Core.Api.Models;
using YourMoney.Standard.Core.Services.Abstract;
using System;
using System.Reactive;
using System.Reactive.Linq;
using ReactiveUI;

namespace YourMoney.Standard.Core.Services.Implementation
{
    public class TransactionService: ITransactionService
    {
        private readonly ITransactionsApi _transactionsApi;

        public TransactionService(ITransactionsApi transactionsApi)
        {
            _transactionsApi = transactionsApi;
        }

        public IObservable<Unit> AddTransaction(TransactionModel transaction)
        {
            return _transactionsApi.CreateTransaction(transaction);
        }

        public IObservable<IEnumerable<TransactionModel>> GetTransactions()
        {
            return _transactionsApi.GetTransactions();
        }

        public IObservable<decimal> GetTotalSum()
        {
            return _transactionsApi
                .GetTotalSum()
                .ObserveOn(RxApp.TaskpoolScheduler)
                .Select(m => m.TotalSum);
        }
    }
}