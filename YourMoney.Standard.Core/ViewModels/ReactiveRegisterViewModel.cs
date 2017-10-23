using System.Reactive.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Input;
using ReactiveUI;
using YourMoney.Standard.Core.Services.Abstract;

namespace YourMoney.Standard.Core.ViewModels
{
    public class ReactiveRegisterViewModel : BaseViewModel
    {
        private const string EmailRegex = @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z";
        private const string PasswordErrorMessage = "Password and confirm password is not equal.";
        private const string EmailErrorMessage = "Please type correct email.";
        private const string ExceptionErrorMessage = "Something go wrong ...";

        private readonly IUserService _userService;
        private readonly IViewModelNavigationService _navigationService;

        private readonly ObservableAsPropertyHelper<string> _error;
        private readonly ObservableAsPropertyHelper<bool> _isUiEnabled;

        private string _userName = string.Empty;
        private string _password = string.Empty;
        private string _email = string.Empty;
        private string _confirmPassword = string.Empty;

        public string UserName
        {
            get => _userName;
            set => this.RaiseAndSetIfChanged(ref _userName, value);
        }

        public string Password
        {
            get => _password;
            set => this.RaiseAndSetIfChanged(ref _password, value);
        }

        public string Email
        {
            get => _email;
            set => this.RaiseAndSetIfChanged(ref _email, value);
        }

        public string ConfirmPassword
        {
            get => _confirmPassword;
            set => this.RaiseAndSetIfChanged(ref _confirmPassword, value);
        }

        public string Error => _error.Value;

        public bool IsUiEnabled => _isUiEnabled.Value;

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

            _isUiEnabled = command.IsExecuting
                .Select(isExecuting => !isExecuting)
                .ToProperty(this, m => m.IsUiEnabled, true);

            RegisterCommand = command;

            var incorrectPassword = this.WhenAnyValue(m => m.Password, m => m.ConfirmPassword)
                .Select(t => t.Item1 != t.Item2 ? PasswordErrorMessage : string.Empty);

            var incorrectEmail = this.WhenAnyValue(m => m.Email)
                .Select(email => !IsValidEmail(email) ? EmailErrorMessage : string.Empty);

            _error = incorrectEmail
                .Merge(incorrectPassword)
                .Merge(unhandledException)
                .Merge(cleanError)
                .ToProperty(this, m => m.Error, string.Empty);
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