using System.Reactive;
using System.Reactive.Linq;
using System.Threading.Tasks;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using YourMoney.Core.Exceptions;
using YourMoney.Core.Extentions;
using YourMoney.Core.Services.Abstract;

namespace YourMoney.Core.ViewModels
{
    public class ReactiveLoginViewModel : BaseViewModel
    {
        private const string LoginErrorMessage = "Login or password is incorrect.";
        private const string UnhandledErrorMessage = "Something go wrong ...";

        private readonly IUserService _userService;
        private readonly IViewModelNavigationService _navigationService;

        public ReactiveLoginViewModel(IUserService userService, IViewModelNavigationService navigationService)
        {
            _userService = userService;
            _navigationService = navigationService;

            var canLogin = this.WhenAnyValue(m => m.UserName, m => m.Password)
                .Select(t => IsValidCredentials(t.Item1, t.Item2));

            LoginCommand = ReactiveCommand.CreateFromTask(LoginAsync, canLogin);

            LoginCommand.IsExecuting
                .Select(isExecuting => !isExecuting)
                .ToPropertyEx(this, m => m.IsUiEnabled);
            var loginError = LoginCommand.ThrownExceptions
                .OnException<ForbiddenApiException>()
                .Select(ex => LoginErrorMessage);
            var unhandledException = LoginCommand.ThrownExceptions
                .Select(ex => UnhandledErrorMessage);

            RegisterCommand = ReactiveCommand.Create(Register);

            unhandledException
                .Merge(loginError)
                .ToPropertyEx(this, m => m.Error);
        }

        [Reactive]
        public string UserName { get; set; }

        [Reactive]
        public string Password { get; set; }

        public extern string Error { [ObservableAsProperty] get; }

        public ReactiveCommand<Unit, Unit> LoginCommand { get; }

        public ReactiveCommand<Unit, Unit> RegisterCommand { get; }

        public extern bool IsUiEnabled { [ObservableAsProperty] get; }

        private bool IsValidCredentials(string userName, string password)
        {
            return !string.IsNullOrWhiteSpace(userName)
                   && !string.IsNullOrWhiteSpace(password)
                   && password.Length >= 6;
        }

        private async Task LoginAsync()
        {
            await _userService.Login(UserName, Password);

            _navigationService.ShowViewModel<ReactiveHomeViewModel>();
        }

        private void Register()
        {
            _navigationService.ShowViewModel<ReactiveRegisterViewModel>();
        }
    }
}