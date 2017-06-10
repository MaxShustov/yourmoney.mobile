using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using YourMoney.Core.Services.Abstract;

namespace YourMoney.Core.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        private readonly IUserService _userService;
        private readonly IViewModelNavigationService _navigationService;

        private string _userName;
        private string _password;

        public LoginViewModel(IUserService userService, IViewModelNavigationService navigationService)
        {
            _userService = userService;
            _navigationService = navigationService;
        }

        public ICommand LoginCommand => new RelayCommand(Login);
        public ICommand RegisterCommand => new RelayCommand(GoToRegister);

        public string UserName
        {
            get
            {
                return _userName;
            }
            set
            {
                Set(() => UserName, ref _userName, value);
            }
        }

        public string Password
        {
            get
            {
                return _password;
            }
            set
            {
                Set(() => Password, ref _password, value);
            }
        }

        private async void Login()
        {
            await _userService.Login(UserName, Password);

            _navigationService.ShowViewModel<HomeViewModel>();
        }

        private void GoToRegister()
        {
            _navigationService.ShowViewModel<RegisterViewModel>();
        }
    }
}