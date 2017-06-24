using System.Reactive;
using System.Reactive.Linq;
using System.Threading.Tasks;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;

namespace YourMoney.Core.ViewModels
{
    public class ReactiveLoginViewModel : BaseViewModel
    {
        private readonly ObservableAsPropertyHelper<bool> _canLogin;
        private ReactiveCommand<Unit, Unit> _loginCommand;

        public ReactiveLoginViewModel()
        {
            var canLogin = this.WhenAnyValue(m => m.UserName, m => m.Password)
                .Select(t => IsValidCredentials(t.Item1, t.Item2));

            _canLogin = canLogin.ToProperty(this, m => m.CanLogin);

            _loginCommand = ReactiveCommand.CreateFromTask(LoginAsync, canLogin);
        }

        [Reactive]
        public string UserName { get; set; }

        [Reactive]
        public string Password { get; set; }

        [Reactive]
        public string Error { get; set; }

        public bool CanLogin => _canLogin.Value;

        public ReactiveCommand<Unit, Unit> LoginCommand => _loginCommand;

        private bool IsValidCredentials(string userName, string password)
        {
            return !string.IsNullOrWhiteSpace(userName)
                   && !string.IsNullOrWhiteSpace(password)
                   && password.Length >= 6;
        }

        private async Task LoginAsync()
        {

        }
    }
}