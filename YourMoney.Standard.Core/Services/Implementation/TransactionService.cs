using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Refit;
using YourMoney.Standard.Core.Api.Interfaces;
using YourMoney.Standard.Core.Api.Models;
using YourMoney.Standard.Core.Entities;
using YourMoney.Standard.Core.Repositories.Abstract;
using YourMoney.Standard.Core.Services.Abstract;

namespace YourMoney.Standard.Core.Services.Implementation
{
    public class TransactionService: ITransactionService
    {
        private readonly ITransactionsApi _transactionsApi;
        private readonly ITransactionsRepository _transactionsRepository;
        private readonly IEntitySyncService<Transaction, string> _syncService;

        public TransactionService(HttpClient httpClient, ITransactionsRepository transactionsRepository, IEntitySyncService<Transaction, string> syncService)
        {
            _transactionsRepository = transactionsRepository;
            _syncService = syncService;
            _transactionsApi = RestService.For<ITransactionsApi>(httpClient);
        }

        public Task AddTransaction(TransactionModel transaction)
        {
            return _transactionsApi.CreateTransaction(transaction);
        }

        public async Task<IEnumerable<TransactionModel>> GetTransactions()
        {
            await _syncService.Sync();

            var transactions = await _transactionsApi.GetTransactions();

            return transactions;
        }

        public async Task<decimal> GetTotalSum()
        {
            var totalSumResponseModel = await _transactionsApi.GetTotalSum();

            return totalSumResponseModel.TotalSum;
        }
    }
}