using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reactive;
using System.Reactive.Linq;
using ReactiveUI;

namespace YourMoney.Droid.Helpers
{
    public static class ReactiveExtentions
    {
        public static IEnumerable<IReactiveBinding<TView, TViewModel, TVProp>> OneWayBindMultiple<TViewModel, TView, TVMProp, TVProp>(
            this TView view,
            TViewModel viewModel,
            Expression<Func<TViewModel, TVMProp>> vmProperty,
            params Expression<Func<TView, TVProp>>[] viewProperties)
            where TViewModel : class where TView : IViewFor
        {
            return viewProperties.Select(viewProperty => view.OneWayBind(viewModel, vmProperty, viewProperty)).ToList();
        }

        public static IDisposable InvokeCommandWithoutParam<TViewModel>(this IObservable<EventArgs> observableEvent, TViewModel viewModel, Expression<Func<TViewModel, ReactiveCommandBase<Unit, Unit>>> commandProperty)
        {
            return observableEvent.Select(e => Unit.Default).InvokeCommand(viewModel, commandProperty);
        }
    }
}