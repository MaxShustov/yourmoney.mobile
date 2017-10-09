using System;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using YourMoney.Core.Enums;
using YourMoney.Core.ViewModels.Abstract;

namespace YourMoney.Core.ViewModels
{
    public class BaseViewModel : ReactiveObject, IViewModel
    {
        protected BaseViewModel()
        {
            StateObservable = this.WhenAnyValue(m => m.State);
        }

        public IObservable<ViewModelState> StateObservable { get; }

        [Reactive]
        public ViewModelState State { get; private set; }

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
    }
}