using System;
using System.Diagnostics;

namespace YourMoney.Standard.Core.Observers
{
    public class ExceptionObserver : IObserver<Exception>
    {
        public void OnCompleted()
        {
            if (Debugger.IsAttached)
            {
                Debugger.Break();
            }
        }

        public void OnError(Exception error)
        {
            if (Debugger.IsAttached)
            {
                Debugger.Break();
            }
            
            Debug.WriteLine($"Exception: {error.Message}");
        }

        public void OnNext(Exception value)
        {
            if (Debugger.IsAttached)
            {
                Debugger.Break();
            }

            Debug.WriteLine($"Exception: {value.Message}");
        }
    }
}