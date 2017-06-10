﻿using System;
using GalaSoft.MvvmLight;
using YourMoney.Core.Services.Abstract;

namespace YourMoney.Core.ViewModels
{
    public class HomeViewModel : ViewModelBase
    {
        private readonly IUserService _userService;
        private readonly Guid _userId;

        private string _currentBalance;

        public HomeViewModel(IUserService userService, ISettingService settingService)
        {
            _userService = userService;

            _userId = settingService.UserId;

            Initialize();
        }

        public string CurrentBalance
        {
            get
            {
                return _currentBalance;
            }
            set
            {
                Set(() => CurrentBalance, ref _currentBalance, value);
            }
        }

        private async void Initialize()
        {
            CurrentBalance = (await _userService.GetCurrentBalance(_userId)).ToString();
        }
    }
}