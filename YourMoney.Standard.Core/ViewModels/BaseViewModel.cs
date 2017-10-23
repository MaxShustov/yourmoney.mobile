using System;
using System.Reactive;
using ReactiveUI;
using YourMoney.Standard.Core.Enums;
using YourMoney.Standard.Core.Observers;
using YourMoney.Standard.Core.ViewModels.Abstract;

namespace YourMoney.Standard.Core.ViewModels
{
    public class BaseViewModel : ReactiveObject, IViewModel
    {
        private ViewModelState _state;

        protected IObserver<Exception> ExceptionObserver;

        protected BaseViewModel()
        {
            StateObservable = this.WhenAnyValue(m => m.State);

            ExceptionObserver = new ExceptionObserver();
        }

        public IObservable<ViewModelState> StateObservable { get; }

        public ViewModelState State
        {
            get => _state;
            private set => this.RaiseAndSetIfChanged(ref _state, value);
        }

        public virtual void Appearing()
        {
        }

        public virtual void Appeared()
        {
            State = ViewModelState.Appeared;
        }

        public virtual void Disappearing()
        {
        }

        public virtual void Disappeared()
        {
            State = ViewModelState.Disappered;
        }

        public virtual void InitWithParam(object navigationParam)
        {
            
        }
    }
}