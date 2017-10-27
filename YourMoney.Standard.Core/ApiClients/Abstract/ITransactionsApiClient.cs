using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using YourMoney.Standard.Core.Api.Models;
using YourMoney.Standard.Core.Entities;

namespace YourMoney.Standard.Core.ApiClients.Abstract
{
    public interface ITransactionsApiClient: IBaseApiClient<Transaction, string>
    {
    }
}