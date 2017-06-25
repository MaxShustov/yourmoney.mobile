using System.Reactive.Linq;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;

namespace YourMoney.Core.ViewModels
{
    public class ReactiveRegisterViewModel : BaseViewModel
    {
        [Reactive]
        public string UserName { get; set; }

        [Reactive]
        public string Password { get; set; }

        [Reactive]
        public string Email { get; set; }

        [Reactive]
        public string ConfirmPassword { get; set; }

        public string Error { [ObservableAsProperty] get; }

        public bool CanRegister { [ObservableAsProperty] get; }

        public ReactiveRegisterViewModel()
        {
            this.WhenAnyValue(m => m.Password, m => m.ConfirmPassword)
                .Where(t => t.Item1 != t.Item2)
                .Select(_ => "Password and confirm password is not equal");

            this.WhenAnyValue(m => m.UserName)
                .Where(userName => userName.Length < 6)
                .Select(_ => "User name length should be greater than 6");

            this.WhenAnyValue(
                    m => m.UserName,
                    m => m.Password,
                    m => m.ConfirmPassword,
                    m => m.Email)
                .Select(t => IsValidData(t.Item1, t.Item2, t.Item3, t.Item4))
                .ToProperty(this, m => m.CanRegister);
        }

        private bool IsValidData(string userName, string password, string confirmPassword, string email)
        {
            return !string.IsNullOrWhiteSpace(userName)
                   && !string.IsNullOrEmpty(password)
                   && !string.IsNullOrWhiteSpace(confirmPassword)
                   && !string.IsNullOrWhiteSpace(email);
        }
    }
}