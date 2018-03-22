using System;
using UIKit;
namespace YourMoney.iOS
{
    public class Theme
    {
        public static readonly UIColor PrimaryColor = UIColor.FromRGB(0x5f, 0xd4, 0xaf);
        public static readonly UIColor PrimaryDarkColor = UIColor.FromRGB(0x00,0x79, 0x6B);
        public static readonly UIColor DarkTextColor = UIColor.FromRGB(0x4f, 0x5a, 0x69);
        public static readonly UIColor LightTextColor = UIColor.FromRGB(0xFA, 0xFA, 0xFA);
        public static readonly UIColor ErrorColor = UIColor.FromRGB(0xE5, 0x39, 0x35);

        public const int ButtonCornerRadius = 8;

        public static void AsPrimaryButton(UIButton button)
        {
            button.SetBackgroundImage(PrimaryColor.AsImage(), UIControlState.Normal);
            button.SetTitleColor(DarkTextColor, UIControlState.Normal);
            button.Layer.CornerRadius = ButtonCornerRadius;
            button.ClipsToBounds = true;
        }

        public static void AsDarkButton(UIButton button)
        {
            button.SetBackgroundImage(PrimaryDarkColor.AsImage(), UIControlState.Normal);
            button.SetTitleColor(LightTextColor, UIControlState.Normal);
            button.Layer.CornerRadius = ButtonCornerRadius;
            button.ClipsToBounds = true;
        }
    }
}
