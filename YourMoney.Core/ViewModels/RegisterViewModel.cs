using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using YourMoney.Core.Services.Abstract;

namespace YourMoney.Core.ViewModels
{
    public class RegisterViewModel : ViewModelBase
    {
        private readonly IUserService _userService;
        private readonly IViewModelNavigationService _navigationService;

        private string _userName;
        private string _password;
        private string _email;
        private bool _isUiEnabled;

        public RegisterViewModel(IUserService userService, IViewModelNavigationService navigationService)
        {
            _userService = userService;
            _navigationService = navigationService;

            _isUiEnabled = true;
        }

        public ICommand RegisterCommand => new RelayCommand(Register);

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

        public string Email
        {
            get
            {
                return _email;
            }
            set
            {
                Set(() => Email, ref _email, value);
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

        private async void Register()
        {
            IsUiEnabled = false;

            await _userService.Register(UserName, Password, Email);

            _navigationService.ShowViewModel<LoginViewModel>();

            IsUiEnabled = true;
        }
    }
}