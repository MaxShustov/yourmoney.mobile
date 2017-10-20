using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Refit;
using YourMoney.Standard.Core.Api.Interfaces;
using YourMoney.Standard.Core.Api.Models;
using YourMoney.Standard.Core.Services.Abstract;

namespace YourMoney.Standard.Core.Services.Implementation
{
    public class TransactionService: ITransactionService
    {
        private readonly ITransactionsApi _transactionsApi;

        public TransactionService(HttpClient httpClient)
        {
            _transactionsApi = RestService.For<ITransactionsApi>(httpClient);
        }

        public Task AddTransaction(TransactionModel transaction)
        {
            return _transactionsApi.CreateTransaction(transaction);
        }

        public Task<IEnumerable<TransactionModel>> GetTransactions()
        {
            return _transactionsApi.GetTransactions();
        }

        public async Task<decimal> GetTotalSum()
        {
            var totalSumResponseModel = await _transactionsApi.GetTotalSum();

            return totalSumResponseModel.TotalSum;
        }
    }
}