using System;
using System.Collections.Generic;

namespace YourMoney.Standard.Core.Services.Abstract
{
    public interface INavigationHelper
    {
        IDictionary<Type, Type> NavigationMap { get; }
    }
}