using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using YourMoney.Core.Services.Abstract;

namespace YourMoney.Core.ViewModels
{
    public class RegisterViewModel : BaseViewModel
    {
        private readonly IUserService _userService;
        private readonly IViewModelNavigationService _navigationService;

        private string _userName;
        private string _password;
        private string _email;
        private string _confirmPassword;
        private string _error;
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

        public string ConfirmPassword
        {
            get
            {
                return _confirmPassword;
            }
            set
            {
                Set(() => ConfirmPassword, ref _confirmPassword, value);
            }
        }

        public string Error
        {
            get
            {
                return _error;
            }
            set
            {
                Set(() => Error, ref _error, value);
            }
        }

        private async void Register()
        {
            IsUiEnabled = false;

            try
            {
                if (ConfirmPassword != Password)
                {
                    Error = "Confirm password and password are not equal.";
                    return;
                }

                await _userService.Register(UserName, Password, Email);

                _navigationService.ShowViewModel<LoginViewModel>();
            }
            finally
            {
                IsUiEnabled = true;
            }
        }
    }
}