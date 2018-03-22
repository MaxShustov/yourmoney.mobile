using System;
using UIKit;
using CoreGraphics;
namespace YourMoney.iOS
{
    public static class Extentions
    {
        public static UIImage AsImage(this UIColor color)
        {
            var rect = new CGRect(0, 0, 1, 1);

            UIGraphics.BeginImageContext(rect.Size);

            CGContext context = UIGraphics.GetCurrentContext();
            context.SetFillColor(color.CGColor);
            context.FillRect(rect);
            var image = UIGraphics.GetImageFromCurrentImageContext();

            UIGraphics.EndImageContext();

            return image;
        }
    }
}
