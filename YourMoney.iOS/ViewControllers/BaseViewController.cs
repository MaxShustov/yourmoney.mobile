using ReactiveUI;
using YourMoney.Standard.Core.ViewModels.Abstract;
using YourMoney.Standard.Core;
using Autofac;
using UIKit;
using Foundation;
using System;
using System.Runtime.CompilerServices;

namespace YourMoney.iOS.ViewControllers
{
    public class BaseViewController<TViewModel> : ReactiveViewController, IViewFor<TViewModel>
        where TViewModel : class, IViewModel
    {
        public BaseViewController()
        {
        }

        public BaseViewController(NSCoder coder)
            : base(coder)
        {
        }

        public BaseViewController(string nibName, NSBundle bundle)
            : base(nibName, bundle)
        {
        }

        protected BaseViewController(NSObjectFlag t)
            : base(t)
        {
        }

        protected internal BaseViewController(IntPtr handle)
            : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            ViewModel = AppStart.Container.Resolve<TViewModel>();
        }

        private TViewModel _viewModel;
        public TViewModel ViewModel 
        {
            get => _viewModel;
            set => this.RaiseAndSetIfChanged(ref _viewModel, value); 
        }

        object IViewFor.ViewModel 
        { 
            get => _viewModel;
            set => ViewModel = (TViewModel)value;
        }
    }
}
