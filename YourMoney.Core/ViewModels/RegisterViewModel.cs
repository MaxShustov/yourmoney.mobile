using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using YourMoney.Core.Services.Abstract;

namespace YourMoney.Core.ViewModels
{
    public class RegisterViewModel : ViewModelBase
    {
        private readonly IUserService _userService;

        private string _userName;
        private string _password;
        private string _email;

        public RegisterViewModel(IUserService userService)
        {
            _userService = userService;
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

        private async void Register()
        {
            await _userService.Register(UserName, Password, Email);
        }
    }
}