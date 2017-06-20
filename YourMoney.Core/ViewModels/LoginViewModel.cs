using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using YourMoney.Core.Services.Abstract;

namespace YourMoney.Core.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        private readonly IUserService _userService;
        private readonly IViewModelNavigationService _navigationService;

        private string _userName;
        private string _password;
        private bool _isUiEnabled;

        public LoginViewModel(IUserService userService, IViewModelNavigationService navigationService)
        {
            _userService = userService;
            _navigationService = navigationService;

            _isUiEnabled = true;

            UserName = string.Empty;
            Password = string.Empty;
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

        public bool IsUiEnabled
        {
            get
            {
                return _isUiEnabled;
            }
            set
            {
                Set(() => IsUiEnabled, ref _isUiEnabled, value);
            }
        }

        private async void Login()
        {
            IsUiEnabled = false;

            await _userService.Login(UserName, Password);

            _navigationService.ShowViewModel<HomeViewModel>();

            IsUiEnabled = true;
        }

        private void GoToRegister()
        {
            _navigationService.ShowViewModel<RegisterViewModel>();
        }
    }
}