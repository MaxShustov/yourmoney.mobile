using Autofac;
using ReactiveUI;
using System;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using YourMoney.Standard.Core;
using YourMoney.Standard.Core.ViewModels;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace YourMoney.UWP
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class HomePage : Page, IViewFor<ReactiveHomeViewModel>
    {
        public HomePage()
        {
            this.InitializeComponent();
        }

        object IViewFor.ViewModel
        {
            get => ViewModel;
            set => throw new NotImplementedException();
        }

        public ReactiveHomeViewModel ViewModel
        {
            get => AppStart.Container.Resolve<ReactiveHomeViewModel>();
            set => throw new NotImplementedException();
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            base.OnNavigatedFrom(e);

            ViewModel.Disappeared();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            ViewModel.Appeared();
        }
    }
}
