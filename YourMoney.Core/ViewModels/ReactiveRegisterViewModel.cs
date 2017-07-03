using System.Reactive.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Input;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using YourMoney.Core.Services.Abstract;

namespace YourMoney.Core.ViewModels
{
    public class ReactiveRegisterViewModel : BaseViewModel
    {
        private const string EmailRegex = @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z";
        private const string PasswordErrorMessage = "Password and confirm password is not equal.";
        private const string EmailErrorMessage = "Please type correct email.";
        private const string ExceptionErrorMessage = "Something go wrong ...";

        private readonly IUserService _userService;
        private readonly IViewModelNavigationService _navigationService;

        [Reactive]
        public string UserName { get; set; } = string.Empty;

        [Reactive]
        public string Password { get; set; } = string.Empty;

        [Reactive]
        public string Email { get; set; } = string.Empty;

        [Reactive]
        public string ConfirmPassword { get; set; } = string.Empty;

        public extern string Error { [ObservableAsProperty] get; }

        public extern bool IsUiEnabled { [ObservableAsProperty] get; }

        public ICommand RegisterCommand { get; }

        public ReactiveRegisterViewModel(IUserService userService, IViewModelNavigationService navigationService)
        {
            _userService = userService;
            _navigationService = navigationService;

            var canRegister = this.WhenAnyValue(
                    m => m.UserName,
                    m => m.Password,
                    m => m.ConfirmPassword,
                    m => m.Email)
                .Select(t => IsValidData(t.Item1, t.Item2, t.Item3, t.Item4));

            var command = ReactiveCommand.CreateFromTask(RegisterAsync, canRegister);
            var unhandledException = command.ThrownExceptions.Select(ex => ExceptionErrorMessage);
            var cleanError = command.IsExecuting.Select(_ => string.Empty);

            command.IsExecuting.Select(isExecuting => !isExecuting).ToPropertyEx(this, m => m.IsUiEnabled);
            RegisterCommand = command;

            var incorrectPassword = this.WhenAnyValue(m => m.Password, m => m.ConfirmPassword)
                .Select(t => t.Item1 != t.Item2 ? PasswordErrorMessage : string.Empty);

            var incorrectEmail = this.WhenAnyValue(m => m.Email)
                .Select(email => !IsValidEmail(email) ? EmailErrorMessage : string.Empty);

            incorrectEmail
                .Merge(incorrectPassword)
                .Merge(unhandledException)
                .Merge(cleanError)
                .ToPropertyEx(this, m => m.Error);
        }

        private bool IsValidData(string userName, string password, string confirmPassword, string email)
        {
            return !string.IsNullOrWhiteSpace(userName)
                   && !string.IsNullOrEmpty(password)
                   && !string.IsNullOrWhiteSpace(confirmPassword)
                   && !string.IsNullOrWhiteSpace(email);
        }

        private bool IsValidEmail(string email)
        {
            return Regex.IsMatch(email, EmailRegex, RegexOptions.IgnoreCase);
        }

        private async Task RegisterAsync()
        {
            await _userService.Register(UserName, Password, Email);

            await _userService.Login(UserName, Password);

            _navigationService.ShowViewModel<ReactiveHomeViewModel>();
        }
    }
}