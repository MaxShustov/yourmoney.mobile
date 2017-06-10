using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using YourMoney.Core.Models;

namespace YourMoney.Core.Services.Abstract
{
    public interface IUserService
    {
        Task Login(string userName, string password);

        Task Register(string userName, string password, string email);

        Task<decimal> GetCurrentBalance(Guid userId);

        Task<List<Transaction>> GetTransactions(Guid userId);
    }
}