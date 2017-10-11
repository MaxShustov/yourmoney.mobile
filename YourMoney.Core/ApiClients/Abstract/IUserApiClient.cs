﻿using System.Collections.Generic;
using System.Threading.Tasks;
using YourMoney.Core.Models;

namespace YourMoney.Core.ApiClients.Abstract
{
    public interface IUserApiClient
    {
        Task<string> Login(LoginModel loginModel);

        Task Register(RegisterModel registerModel);
    }
}