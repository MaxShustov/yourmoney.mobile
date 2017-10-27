using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using AutoMapper;
using Refit;
using YourMoney.Standard.Core.Api.Interfaces;
using YourMoney.Standard.Core.Api.Models;
using YourMoney.Standard.Core.ApiClients.Abstract;
using YourMoney.Standard.Core.Entities;

namespace YourMoney.Standard.Core.ApiClients.Implementation
{
    public class TransactionsApiClient: ITransactionsApiClient
    {
        private readonly IMapper _mapper;
        private readonly ITransactionsApi _transactionsApi;

        public TransactionsApiClient(HttpClient httpClient, IMapper mapper)
        {
            _mapper = mapper;
            _transactionsApi = RestService.For<ITransactionsApi>(httpClient);
        }

        public Task<Transaction> GetAsync(string key)
        {
            throw new System.NotImplementedException();
        }

        public async Task<IEnumerable<Transaction>> GetAsync(DateTime? updatedDate)
        {
            var transactions = await _transactionsApi.GetTransactions(updatedDate).ConfigureAwait(false);

            return _mapper.Map<IEnumerable<Transaction>>(transactions);
        }

        public Task AddAsync(Transaction entity)
        {
            throw new System.NotImplementedException();
        }

        public Task UpdateAsync(Transaction entity)
        {
            throw new System.NotImplementedException();
        }

        public Task DeleteAsync(Transaction entity)
        {
            throw new System.NotImplementedException();
        }
    }
}