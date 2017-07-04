using System;

namespace YourMoney.Droid.Attributes
{
    public class NavigationAttribute : Attribute
    {
        public bool Root { get; set; } = false;

        public bool History { get; set; } = true;
    }
}