using System.Reactive;
using System.Reactive.Linq;
using System.Threading.Tasks;
using ReactiveUI;
using YourMoney.Standard.Core.Services.Abstract;

namespace YourMoney.Standard.Core.ViewModels
{
    public class ReactiveLoginViewModel : BaseViewModel
    {
        private const string LoginErrorMessage = "Login or password is incorrect.";
        private const string UnhandledErrorMessage = "Something go wrong ...";

        private readonly IUserService _userService;
        private readonly IViewModelNavigationService _navigationService;

        private readonly ObservableAsPropertyHelper<bool> _isUiEnabled;
        private readonly ObservableAsPropertyHelper<string> _error;
        private string _userName;
        private string _password;

        public ReactiveLoginViewModel(IUserService userService, IViewModelNavigationService navigationService)
        {
            _userService = userService;
            _navigationService = navigationService;

            var canLogin = this.WhenAnyValue(m => m.UserName, m => m.Password)
                .Select(t => IsValidCredentials(t.Item1, t.Item2));

            LoginCommand = ReactiveCommand.CreateFromTask(LoginAsync, canLogin);

            _isUiEnabled = LoginCommand.IsExecuting
                .Select(isExecuting => !isExecuting)
                .ToProperty(this, m => m.IsUiEnabled, true);

            var unhandledException = LoginCommand.ThrownExceptions
                .Select(ex => UnhandledErrorMessage);

            LoginCommand
                .Subscribe(Observer.Create<Unit>(OnSuccessfulLogin));

            RegisterCommand = ReactiveCommand.Create(Register);

            _error = unhandledException
                .ToProperty(this, m => m.Error, string.Empty);
        }

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

        public string Error => _error.Value;

        public ReactiveCommand<Unit, Unit> LoginCommand { get; }

        public ReactiveCommand<Unit, Unit> RegisterCommand { get; }

        public bool IsUiEnabled => _isUiEnabled.Value;

        private bool IsValidCredentials(string userName, string password)
        {
            return !string.IsNullOrWhiteSpace(userName)
                   && !string.IsNullOrWhiteSpace(password);
        }

        private Task LoginAsync()
        {
            return _userService.Login(UserName, Password);
        }

        private void OnSuccessfulLogin(Unit unit)
        {
            _navigationService.ShowViewModel<ReactiveHomeViewModel>();
        }

        private void Register()
        {
            _navigationService.ShowViewModel<ReactiveRegisterViewModel>();
        }
    }
}