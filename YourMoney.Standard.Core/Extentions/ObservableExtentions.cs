using System;
using System.Reactive.Linq;

namespace YourMoney.Standard.Core.Extentions
{
    public static class ObservableExtentions
    {
        public static IObservable<Exception> OnException<TException>(this IObservable<Exception> observable)
            where TException : Exception
        {
            return observable.Where(e => e.GetType() == typeof(TException));
        }
    }
}