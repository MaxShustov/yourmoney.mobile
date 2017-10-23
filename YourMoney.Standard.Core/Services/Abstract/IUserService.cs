﻿using System.Threading.Tasks;

namespace YourMoney.Standard.Core.Services.Abstract
{
    public interface IUserService
    {
        Task Login(string userName, string password);

        Task Register(string userName, string password, string email);
    }
}