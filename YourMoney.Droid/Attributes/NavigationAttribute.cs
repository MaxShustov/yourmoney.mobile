using System;

namespace YourMoney.Droid.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public class NavigationAttribute : Attribute
    {
        public bool Root { get; set; } = false;

        public bool History { get; set; } = true;
    }
}