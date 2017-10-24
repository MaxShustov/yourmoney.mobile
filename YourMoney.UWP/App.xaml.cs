using Autofac;
using System;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using YourMoney.Standard.Core;
using YourMoney.Standard.Core.Services.Abstract;
using YourMoney.Standard.Core.Utils;
using YourMoney.UWP.Services;

namespace YourMoney.UWP
{
    sealed partial class App : Application
    {
        public App()
        {
            this.InitializeComponent();
            this.Suspending += OnSuspending;
        }

        protected override void OnLaunched(LaunchActivatedEventArgs e)
        {
            AppStart.Initialize(RegisterInnerDependencies);
            //#if DEBUG
            //            if (System.Diagnostics.Debugger.IsAttached)
            //            {
            //                this.DebugSettings.EnableFrameRateCounter = true;
            //            }
            //#endif
            Frame rootFrame = Window.Current.Content as Frame;

            if (rootFrame == null)
            {
                rootFrame = new Frame();

                rootFrame.NavigationFailed += OnNavigationFailed;
                rootFrame.Navigated += OnNavigated;

                if (e.PreviousExecutionState == ApplicationExecutionState.Terminated)
                {
                }

                Window.Current.Content = rootFrame;

                SystemNavigationManager.GetForCurrentView().BackRequested += OnBackRequested;

                SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility = rootFrame.CanGoBack
                    ? AppViewBackButtonVisibility.Visible
                    : AppViewBackButtonVisibility.Collapsed;
            }

            if (e.PrelaunchActivated == false)
            {
                if (rootFrame.Content == null)
                {
                    rootFrame.Navigate(typeof(LoginPage), e.Arguments);
                }

                Window.Current.Activate();
            }

            SetWindowTitleColor();
        }

        private void OnBackRequested(object sender, BackRequestedEventArgs backRequestedEventArgs)
        {
            Frame rootFrame = Window.Current.Content as Frame;

            if (rootFrame.CanGoBack)
            {
                backRequestedEventArgs.Handled = true;
                rootFrame.GoBack();
            }
        }

        private void OnNavigated(object sender, NavigationEventArgs navigationEventArgs)
        {
            SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility = ((Frame)sender).CanGoBack
                ? AppViewBackButtonVisibility.Visible
                : AppViewBackButtonVisibility.Collapsed;
        }

        void OnNavigationFailed(object sender, NavigationFailedEventArgs e)
        {
            throw new Exception("Failed to load Page " + e.SourcePageType.FullName);
        }

        private void OnSuspending(object sender, SuspendingEventArgs e)
        {
            var deferral = e.SuspendingOperation.GetDeferral();

            deferral.Complete();
        }

        private void RegisterInnerDependencies(ContainerBuilder builder)
        {
            builder.RegisterType<ViewModelNavigationService>().As<IViewModelNavigationService>().SingleInstance();
            builder.RegisterType<PathProvider>().As<IPathProvider>();
        }

        private void SetWindowTitleColor()
        {
            var titleBar = Windows.UI.ViewManagement.ApplicationView.GetForCurrentView().TitleBar;

            var dictionary = (ResourceDictionary)Current.Resources["Resources"];

            var primaryBrush = (SolidColorBrush)dictionary["PrimaryBrush"];
            var primaryDarkBrush = (SolidColorBrush)dictionary["PrimaryDarkBrush"];
            var lightTextBrush = (SolidColorBrush)dictionary["LightTextBrush"];
            var darkTextBrush = (SolidColorBrush)dictionary["DarkTextBrush"];

            titleBar.BackgroundColor = primaryDarkBrush.Color;
            titleBar.ForegroundColor = lightTextBrush.Color;
            titleBar.ButtonBackgroundColor = primaryDarkBrush.Color;
            titleBar.ButtonForegroundColor = lightTextBrush.Color;
            //--
            titleBar.ButtonHoverBackgroundColor = primaryBrush.Color;
            titleBar.ButtonHoverForegroundColor = darkTextBrush.Color;
            titleBar.ButtonPressedBackgroundColor = primaryBrush.Color;
            titleBar.ButtonPressedForegroundColor = darkTextBrush.Color;
            titleBar.InactiveBackgroundColor = primaryBrush.Color;
            titleBar.InactiveForegroundColor = darkTextBrush.Color;
            titleBar.ButtonInactiveBackgroundColor = primaryBrush.Color;
            titleBar.ButtonInactiveForegroundColor = darkTextBrush.Color;
        }
    }
}
